# SeaPower PLANS Compatibility

[简体中文](REAME-zh_CN.md)

This project serves as an integration and compatibility mod for *Sea Power*, encompassing the following mods: PLAN, 095A, PLAN Submarines, and Console++. The objective of this project is to ensure compatibility between weapon launch and rearming mechanics, while unifying ammunition types and their performance characteristics.

The patch lets Console++ **Unlimited Ammo** rearm vertical launch cells on player-controlled Type 095A submarines. A cell becomes available again after Console++ restores a round and the Type 095A launch routine finishes.

The default magazines on PLAN Submarines' Type 09X, Type 095 and Type 093B use the Type 095A YJ-18B and submarine-launched CJ-10, plus the PLAN Pack Yu-9 and Yu-10. Each boat takes its ammunition quantities from PLAN Submarines. The CJ-10 follows target coordinates with zero simulated inertial drift and can receive midcourse datalink updates.

PLAN Submarines' Type 093, Type 093A, Type 039 and Type 039A use Yu-9 in place of Yu-6. Type 094A, Type 039B and Type 039C use the electric Yu-10 in place of Yu-6. Type 095A carries Yu-9 in place of Yu-6A, and Type 095 gets two Yu-12A torpedoes for interception. The shared electric Yu-10 can reach 60 knots, with a 0.5–32 nautical mile launch envelope and PLAN Pack's wire settings.

## Requirements

- [Console++](https://steamcommunity.com/sharedfiles/filedetails/?id=3782661493) and [Type 095A Runtime](https://steamcommunity.com/sharedfiles/filedetails/?id=3815454553) for the Type 095A rearm patch.
- [R.A.T.S. Keel](https://steamcommunity.com/sharedfiles/filedetails/?id=3835527459) or [Anchor Chain](https://steamcommunity.com/sharedfiles/filedetails/?id=3380210757) to load the patch.

Enable [PLAN Submarines](https://steamcommunity.com/sharedfiles/filedetails/?id=3594891803), [PLAN Pack](https://steamcommunity.com/sharedfiles/filedetails/?id=3775128499), and Type 095A for the integrated submarine loadouts. The submarine-launched CJ-10 inherits its base definition from PLAN Pack. [Cooperative Midcourse Guidance](https://steamcommunity.com/sharedfiles/filedetails/?id=3838908720) provides optional updates from friendly radar tracks.

## Install and use

1. Subscribe to the mod and its required items in the [Sea Power Steam Workshop](https://steamcommunity.com/app/1286220/workshop/). Steam downloads the files automatically.
2. In the game's mod list, enable the required mods and this patch. Place the patch below Console++ and Type 095A Runtime, then restart Sea Power.
3. In a mission, press **F8** to open Console++, enable **Unlimited Ammo**, and launch from a player-controlled Type 095A.

To remove the patch, disable it in the mod list and restart the game.

## Build from source

Install a .NET SDK and make sure your Sea Power installation contains the game assemblies and `BepInEx/core/0Harmony.dll`. The build also reads `AnchorChain.dll` from Workshop item `3380210757`.

```powershell
dotnet build sppc.csproj -c Release
```

The project defaults to a Steam library at `D:\Steam`. For another library, pass the game directory and the Sea Power Workshop content directory separately.

```powershell
dotnet build sppc.csproj -c Release `
  '-p:SeaPowerDir=E:\SteamLibrary\steamapps\common\Sea Power' `
  '-p:WorkshopDir=E:\SteamLibrary\steamapps\workshop\content\1286220'
```

The package assets live in `WorkshopSource/`. A Release build combines them with `sppc.dll` in `Workshop/sppc/`. Use the generated folder as the Workshop content directory and `preview.jpg` as its preview image.

To install a local build, copy the entire generated `Workshop/sppc/` folder, including `overrides/`, to `<SeaPowerDir>/Sea Power_Data/StreamingAssets/`. Enable it in the mod list and restart the game.

## In-game verification

The patch logs `[Console++ / 095A] Installed` in `BepInEx/LogOutput.log` or `BepInEx/Keel-log.txt` when it loads. Repeat YJ-20 launches from the same Type 095A cell have been observed in-game.

The Type 09X loadout was confirmed in-game to include the submarine-launched CJ-10 during the first integration. For the expanded loadouts, start a new mission. Check for eight submarine-launched CJ-10s on Type 09X and six each on Type 095 and Type 093B. Test coordinate flight and datalink updates separately using an eligible tracked target for the latter. In-game checks of the expanded loadouts are pending.

To verify rearming, try repeat launches of the submarine-launched YJ-20 and YJ-18B. Match the `unit`, `system`, and `cell` values between the `Rearmed` and 095A VLS log entries and check for a second `outcome=Launched` from the same cell. Disable Unlimited Ammo and check that further launches consume the remaining rounds normally.

## License

[MIT](LICENSE)
