# SeaPower-PLANS-Compatibility

This project serves as an integration and compatibility mod for *Sea Power*, encompassing the following mods: PLAN, 095A, PLAN Submarines, and Console++. The objective of this project is to ensure compatibility between weapon launch and rearming mechanics, while unifying ammunition types and their performance characteristics.

The current patch, `Console095ACompatibility` v0.1.0, lets Console++ **Unlimited Ammo** rearm vertical launch cells on player-controlled Type 095A submarines. A cell becomes available again after Console++ restores a round and the Type 095A launch routine finishes.

## Requirements

| Dependency | Build reference |
| --- | --- |
| Sea Power | 0.9.3-261116 |
| [Console++](https://steamcommunity.com/sharedfiles/filedetails/?id=3782661493) | 0.42.0 |
| [Type 095A Runtime](https://steamcommunity.com/sharedfiles/filedetails/?id=3815454553) | 1.9.10 |
| [Anchor Chain](https://steamcommunity.com/sharedfiles/filedetails/?id=3380210757) or R.A.T.S. Keel | Anchor Chain 1.2.0 and Harmony 2.9.0 |

## Install and use

1. Copy `Workshop/Console095ACompatibility/` to `<SeaPowerDir>/Sea Power_Data/StreamingAssets/`. The copied folder needs `_info.ini` and `Console095ACompatibility.dll`. The build below copies the DLL into the source package.
2. In the game's mod list, enable the patch below Console++ and Type 095A Runtime, then restart Sea Power.
3. In a mission, press **F8** to open Console++, enable **Unlimited Ammo**, and launch from a player-controlled Type 095A.

To remove the patch, disable it in the mod list and restart the game.

## Build from source

Install a .NET SDK and make sure your Sea Power installation contains the game assemblies and `BepInEx/core/0Harmony.dll`. The build also reads `AnchorChain.dll` from Workshop item `3380210757`.

```powershell
dotnet build Console095ACompatibility.csproj -c Release
```

The project defaults to a Steam library at `D:\Steam`. For another library, pass the game directory and the Sea Power Workshop content directory separately.

```powershell
dotnet build Console095ACompatibility.csproj -c Release `
  '-p:SeaPowerDir=E:\SteamLibrary\steamapps\common\Sea Power' `
  '-p:WorkshopDir=E:\SteamLibrary\steamapps\workshop\content\1286220'
```

The project targets `netstandard2.1`. A Release build copies the compiled DLL to `Workshop/Console095ACompatibility/`. Use that folder as the Workshop package and `preview.jpg` as the preview image. List Console++ and Type 095A Runtime as required items when publishing.

## In-game verification

In-game verification is pending. The patch logs `[Console++ / 095A] Installed` in `BepInEx/LogOutput.log` or `BepInEx/Keel-log.txt` when it loads.

To verify rearming, try repeat launches of the submarine-launched YJ-20 and YJ-18B. Match the `unit`, `system`, and `cell` values between the `Rearmed` and 095A VLS log entries and check for a second `outcome=Launched` from the same cell. Disable Unlimited Ammo and check that further launches consume the remaining rounds normally.

## License

[MIT](LICENSE)
