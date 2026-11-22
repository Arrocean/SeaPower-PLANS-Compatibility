# SeaPower PLANS Compatibility

[简体中文](REAME-zh_CN.md)

This *Sea Power* mod integrates submarine loadouts from PLAN Pack, Type 095A, and PLAN Submarines.

The Type 095A retains its original ready rounds in all four loadouts. Each loadout carries two reserve rounds for each missile type it already carries, covering the submarine-launched YJ-20, YJ-18B, and submarine-launched CJ-10. Each group of launch cells draws from a magazine dedicated to its missile type. The game handles reloading through its native magazine system. Console++ is optional.

The default magazines on PLAN Submarines' Type 09X, Type 095 and Type 093B use the Type 095A YJ-18B and submarine-launched CJ-10, plus the PLAN Pack Yu-9 and Yu-10. Each boat takes its ammunition quantities from PLAN Submarines. The CJ-10 follows target coordinates with zero simulated inertial drift and can receive midcourse datalink updates.

PLAN Submarines' Type 093, Type 093A, Type 039 and Type 039A use Yu-9 in place of Yu-6. Type 094A, Type 096, Type 039B and Type 039C use the electric Yu-10 in place of Yu-6. Type 095A carries Yu-9 in place of Yu-6A, and Type 095 gets two Yu-12A torpedoes for interception. The shared electric Yu-10 can reach 60 knots, with a 0.5–32 nautical mile launch envelope and PLAN Pack's wire settings.

The 2026 Type 055 carries eight Yu-12As in each side's torpedo magazine. The Z-20F carries two air-dropped Yu-12As in its ASW loadout, and the Yu-15 delivers one of the same air-dropped variant.

## Requirements

- Enable Type 095A Runtime and follow its loader requirements. [Type 095A Runtime](https://steamcommunity.com/sharedfiles/filedetails/?id=3815454553)
- Enable PLAN Submarines and PLAN Pack for the integrated loadouts. The submarine-launched CJ-10 inherits its base definition from PLAN Pack. [PLAN Submarines](https://steamcommunity.com/sharedfiles/filedetails/?id=3594891803), [PLAN Pack](https://steamcommunity.com/sharedfiles/filedetails/?id=3775128499)
- Cooperative Midcourse Guidance provides optional updates from friendly radar tracks. [Cooperative Midcourse Guidance](https://steamcommunity.com/sharedfiles/filedetails/?id=3838908720)

## Install and use

1. Subscribe to the mod and its required items. Steam downloads the files automatically. [Sea Power Steam Workshop](https://steamcommunity.com/app/1286220/workshop/)
2. Enable the required mods and this patch in the game's mod list. Place the patch below the mods it updates, then restart Sea Power.
3. Start a new mission with a Type 095A to use the new magazines.

To remove the patch, disable it in the mod list and restart the game.

## Build from source

Install the .NET SDK selected by `global.json` and run the package build.

```powershell
dotnet build sppc.csproj -c Release
```

The build stages the INI overrides, Workshop metadata, preview, and README from `WorkshopSource/` in `Workshop/sppc/`. Use the generated folder as the Workshop content directory and `preview.jpg` as its preview image.

To install a local build, close the game and copy the entire generated `Workshop/sppc/` folder, including `overrides/`, to `<SeaPowerDir>/Sea Power_Data/StreamingAssets/`. When upgrading a manual install, replace the old `sppc` folder to remove the retired `sppc.dll`. Enable the mod in the game's mod list and restart the game.

## In-game verification

In a new mission, use the Type 095A's Default loadout with Console++ Unlimited Ammo off. The YJ-20 and YJ-18B should each have six ready rounds, and the CJ-10 should have twelve. Each type should also have two reserve rounds. Fire the ready rounds and verify that the native reload makes the remaining rounds available. If you use Console++, also test sustained fire with Unlimited Ammo on.

The Type 09X loadout was confirmed in-game to include the submarine-launched CJ-10 during the first integration. For the expanded loadouts, start a new mission. Check for eight submarine-launched CJ-10s on Type 09X and six each on Type 095 and Type 093B. Test coordinate flight and datalink updates separately using an eligible tracked target for the latter. In-game checks of the expanded loadouts are pending.

## License

[MIT](LICENSE)
