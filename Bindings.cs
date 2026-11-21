using System;
using System.Linq;
using System.Reflection;
using SeaPower;

namespace sppc;

internal sealed class Bindings
{
    private readonly MethodInfo unlimitedAmmo;
    private readonly MethodInfo isPlayerOwned;
    private readonly MethodInfo applies;
    private readonly MethodInfo state;
    private readonly MethodInfo launchCandidate;
    private readonly MethodInfo hide;
    private readonly FieldInfo policy;
    private readonly FieldInfo busy;
    private readonly FieldInfo spent;
    private readonly MethodInfo refilled;

    internal Assembly SubmarineAssembly { get; }

    internal Bindings()
    {
        var console = ModAssembly("SeaPowerCheatMenu").GetType("SeaPowerCheatMenu.Cheats", throwOnError: true)!;
        SubmarineAssembly = ModAssembly("plan_ssn_type_095a");
        var vls = SubmarineAssembly.GetType("Type095A.VlsRuntime", throwOnError: true)!;
        var cell = SubmarineAssembly.GetType("Type095A.VlsRuntime+Cell", throwOnError: true)!;
        var cellPolicy = SubmarineAssembly.GetType("Type095A.VlsCellPolicy", throwOnError: true)!;

        unlimitedAmmo = RequireMethod(console, "get_UnlimitedAmmo", typeof(bool), isStatic: true);
        isPlayerOwned = RequireMethod(console, "IsPlayerOwned", typeof(bool), isStatic: true, typeof(ObjectBase));
        applies = RequireMethod(vls, "Applies", typeof(bool), isStatic: true, typeof(WeaponContainer));
        state = RequireMethod(vls, "State", cell, isStatic: true, typeof(WeaponContainer));
        launchCandidate = RequireMethod(vls, "LaunchCandidate", typeof(WeaponBase), isStatic: true,
            typeof(WeaponContainer), typeof(string));
        hide = RequireMethod(vls, "Hide", typeof(void), isStatic: true, typeof(WeaponContainer));
        policy = RequireField(cell, "Policy", cellPolicy);
        busy = RequireField(cellPolicy, "Busy", typeof(bool));
        spent = RequireField(cellPolicy, "Spent", typeof(bool));
        refilled = RequireMethod(cellPolicy, "Refilled", typeof(void), isStatic: false, typeof(int), typeof(int));
    }

    internal bool UnlimitedAmmo() => unlimitedAmmo.Invoke(null, null) is true;
    internal bool IsPlayerOwned(ObjectBase owner) => isPlayerOwned.Invoke(null, new object[] { owner }) is true;
    internal bool Applies(WeaponContainer container) => applies.Invoke(null, new object[] { container }) is true;

    internal object GetPolicy(WeaponContainer container) =>
        policy.GetValue(state.Invoke(null, new object[] { container }))!;

    internal bool IsBusy(object cellPolicy) => busy.GetValue(cellPolicy) is true;
    internal bool IsSpent(object cellPolicy) => spent.GetValue(cellPolicy) is true;

    internal bool HasRound(WeaponContainer container, string ammoName) =>
        (launchCandidate.Invoke(null, new object[] { container, ammoName }) as WeaponBase) != null;

    internal void MarkRefilled(object cellPolicy, int added) => refilled.Invoke(cellPolicy, new object[] { added, added });
    internal void RefreshVisuals(WeaponContainer container) => hide.Invoke(null, new object[] { container });

    private static Assembly ModAssembly(string name) =>
        AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name)
        ?? throw new TypeLoadException($"Mod assembly {name} is unavailable.");

    private static MethodInfo RequireMethod(Type type, string name, Type result, bool isStatic, params Type[] parameters)
    {
        const BindingFlags visibility = BindingFlags.Public | BindingFlags.NonPublic;
        var flags = visibility | (isStatic ? BindingFlags.Static : BindingFlags.Instance);
        var method = type.GetMethod(name, flags, null, parameters, null);
        return method != null && method.ReturnType == result ? method : throw new MissingMethodException(type.FullName, name);
    }

    private static FieldInfo RequireField(Type type, string name, Type fieldType)
    {
        var field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        return field != null && field.FieldType == fieldType ? field : throw new MissingFieldException(type.FullName, name);
    }
}
