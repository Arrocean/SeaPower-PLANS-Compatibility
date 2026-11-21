using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AnchorChain;
using HarmonyLib;
using SeaPower;
using UnityEngine;

namespace Console095ACompatibility;

[ACDependency(Plugin.ConsoleId, "0.42.0", null)]
[ACDependency(Plugin.SubmarineId, "1.9.10", null)]
[ACPlugin(Plugin.Id, "Console++ / Type 095A Compatibility", "0.1.0", null,
    new[] { Plugin.ConsoleId, Plugin.SubmarineId })]
public sealed class Plugin : IAnchorChainMod
{
    internal const string Id = "local.console095a.compatibility";
    internal const string ConsoleId = "jack.seapower.cheatmenu";
    internal const string SubmarineId = "local.plan_ssn_type_095a.runtime";
    private const string LogPrefix = "[Console++ / 095A] ";

    private static readonly ConditionalWeakTable<WeaponContainer, Refill> Pending = new();
    private static Bindings? bindings;

    public void TriggerEntryPoint()
    {
        if (bindings != null)
            return;

        var restore = AccessTools.Method(typeof(WeaponContainer), nameof(WeaponContainer.RestoreWeapons),
            new[] { typeof(Ammunition), typeof(int) });
        var launch = AccessTools.Method(typeof(WeaponContainer), nameof(WeaponContainer.launch),
            new[] { typeof(ObjectBase), typeof(Vector3), typeof(Vector3), typeof(float), typeof(string), typeof(bool) });
        if (restore == null || restore.ReturnType != typeof(int) || launch == null || launch.ReturnType != typeof(bool))
            throw new NotSupportedException(LogPrefix + "Unsupported WeaponContainer signatures.");

        var api = new Bindings();
        var vlsFinalizer = Harmony.GetPatchInfo(launch)?.Finalizers.SingleOrDefault(patch =>
            patch.PatchMethod.DeclaringType?.FullName == "Type095A.VlsLaunch" &&
            patch.PatchMethod.DeclaringType.Assembly == api.SubmarineAssembly);
        if (vlsFinalizer == null)
            throw new InvalidOperationException(LogPrefix + "095A launch patch is missing. Check its startup log.");

        var harmony = new Harmony(Id);
        try
        {
            if (Harmony.HasAnyPatches(Id))
                harmony.UnpatchSelf();

            harmony.Patch(restore, postfix: new HarmonyMethod(typeof(Plugin), nameof(AfterRestore)));
            harmony.Patch(launch, finalizer: new HarmonyMethod(typeof(Plugin), nameof(AfterLaunch))
            {
                priority = Priority.Last,
                after = new[] { vlsFinalizer.owner }
            });
            bindings = api;
        }
        catch
        {
            harmony.UnpatchSelf();
            throw;
        }

        Debug.Log(LogPrefix + "Installed. Rearms player 095A VLS cells with Console++ Unlimited Ammo.");
    }

    private static void AfterRestore(WeaponContainer __instance, Ammunition __0, int __result)
    {
        var api = bindings;
        var ammoName = __0?._ap?._ammunitionFileName;
        if (api == null || __result <= 0 || string.IsNullOrEmpty(ammoName))
            return;

        try
        {
            var owner = EligibleOwner(api, __instance);
            if (owner == null)
                return;

            var refill = new Refill(ammoName!, __result);
            Pending.Remove(__instance);
            if (!ApplyWhenIdle(api, __instance, owner, refill))
                Pending.Add(__instance, refill);
        }
        catch (Exception error)
        {
            Disable(error);
        }
    }

    private static Exception? AfterLaunch(WeaponContainer __instance, Exception? __exception)
    {
        var api = bindings;
        if (api == null || !Pending.TryGetValue(__instance, out var refill))
            return __exception;

        try
        {
            var owner = __exception == null ? EligibleOwner(api, __instance) : null;
            if (owner == null || ApplyWhenIdle(api, __instance, owner, refill))
                Pending.Remove(__instance);
        }
        catch (Exception error)
        {
            Disable(error);
        }

        return __exception;
    }

    private static ObjectBase? EligibleOwner(Bindings api, WeaponContainer container)
    {
        var owner = container._weaponSystem?._baseObject;
        return owner != null && !owner.IsDestroyed && api.Applies(container) &&
            api.UnlimitedAmmo() && api.IsPlayerOwned(owner) ? owner : null;
    }

    // A refill inside launch() can arrive before 095A marks the outgoing round as consumed.
    private static bool ApplyWhenIdle(Bindings api, WeaponContainer container, ObjectBase owner, Refill refill)
    {
        var policy = api.GetPolicy(container);
        if (api.IsBusy(policy))
            return false;

        if (api.IsSpent(policy) && api.HasRound(container, refill.AmmoName))
        {
            api.MarkRefilled(policy, refill.Added);
            api.RefreshVisuals(container);
            Debug.Log(LogPrefix + $"Rearmed unit={owner.getUIDAndName()} " +
                $"system={container._weaponSystem._vwp._sectionName} cell={container._containerIndex} ammo={refill.AmmoName}");
        }

        return true;
    }

    private static void Disable(Exception error)
    {
        bindings = null;
        Debug.LogWarning(LogPrefix + "Disabled after a runtime error. " + error.GetBaseException());
    }

    private sealed class Refill
    {
        internal string AmmoName { get; }
        internal int Added { get; }

        internal Refill(string ammoName, int added)
        {
            AmmoName = ammoName;
            Added = added;
        }
    }
}
