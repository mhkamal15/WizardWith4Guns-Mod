# Wizard with a Gun - 4-Player Co-op Mod

This mod allows you to play 'Wizard with a Gun' with up to 4 players in co-op mode, instead of the default 2 players. It extends the game's built-in co-op functionality to provide a more immersive multiplayer experience.

## Installation

1. **Backup** your game files: Before installing the mod, it's recommended to make a backup of your game files. This will ensure you can revert back to the original game if needed.

2. Install BepinEx Framework:
   - Download the latest version of BepinEx from its official GitHub repository.
   - Extract the contents of the downloaded archive into the game's root folder.

3. Obtain the Assembly-CSharp.dll file: 
   - Locate the 'Assembly-CSharp.dll' file in the game's installation folder. This file contains the game's compiled code.
   - Make a copy of this file and keep it as a backup.

4. Decompile Assembly-CSharp.dll:
   - Use a decompiler tool like dnSpy or ILSpy to decompile the 'Assembly-CSharp.dll' file.
   - Explore the decompiled code to identify the necessary class and method responsible for co-op gameplay.

5. Update the mod code:
   - Open the 'WizardWith4Guns.cs' file provided in this mod's repository.
   - Replace the placeholders "Assembly_CSharp.Coop.CoOpClass" and "Enable2PlayerCoOp" with the actual class and method names you found during decompilation.

6. Installing the mod:
   - Copy the generated mod DLL file to the 'BepinEx/plugins' folder in the game's installation directory.

7. Launch the game:
   - Start the game through the Steam client or by running the game executable.
   - The mod should automatically load and enable 4-player co-op functionality.

## Known Limitations/Issues

- This mod relies on decompiling and modifying the game's assembly file, which might be considered a violation of the game's terms of service. Use this mod at your own risk.
- The mod might not be compatible with future updates of the game. If the game receives an update, the mod might need to be recompiled and updated accordingly.
- Multiplayer experience might be affected if all players don't have the mod installed. It's recommended for all players to have the mod to ensure compatibility.

## Contributions
Mod was created by Malek Kamal in Dec. of 2023.
Contributions to this mod are welcome! If you have any improvements, bug fixes, or additional features to suggest, feel free to create a pull request on the GitHub repository.

## License
This mod is released under the [MIT License](LICENSE).
Note: Make sure to adapt the installation steps and limitations/known issues according to the specifications of the 'Wizard with a Gun' modding community and any additional guidelines or requirements they provide.
