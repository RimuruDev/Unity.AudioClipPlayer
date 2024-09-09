# Unity Audio Clip Player

A simple editor window for Unity that allows you to load and play multiple audio clips directly from the Unity editor. This tool is helpful for game developers and sound designers who need to quickly preview audio files without the need to run the game or manually assign clips to objects.

[Audio Clip Player Window](https://github.com/RimuruDev/Unity.AudioClipPlayer)

## Features

- Load multiple audio clips from a selected folder within the Unity project.
- Preview audio clips directly within the editor without playing the game.
- Supports looping audio playback.
- Remove individual audio clips or clear the entire list with one click.
- Stop playback of all clips at any time.

## Why Use This Tool?

When developing games or working with large audio assets, it can be tedious to manually assign and play clips within the scene, especially for testing purposes. This tool allows you to:

- **Quickly browse and preview** multiple audio clips without running your game.
- **Organize your audio assets** by loading clips directly from specific folders.
- **Save time and effort** by providing a simple UI for playback, looping, and stopping audio clips.

Whether you're a game developer or sound designer, this tool can simplify the process of working with large collections of audio files in Unity.

## Installation

1. Download or clone this repository to your Unity project.
2. Copy the `AudioClipPlayerWindow` script to your `Editor` folder in Unity (if the folder doesn't exist, create one).
3. Once the script is in your project, Unity will automatically compile it and make the new editor window available.

## How to Use

1. Open Unity and go to `RimuruDev Tools` in the top menu bar.
2. Click on `Audio Clip Player` to open the tool.
3. In the window that appears:
   - Click `Select Folder and Load Audio Clips` to choose a folder containing audio files.
   - The tool will automatically find and display all audio clips in the selected folder.
4. From here, you can:
   - **Play individual clips** by clicking the `Play` button next to each one.
   - **Remove clips** from the list using the `Remove` button.
   - **Enable looping** for audio playback by checking the `Loop` checkbox.
   - **Clear all clips** by pressing the `Clear All` button.
   - **Stop all currently playing clips** by pressing the `Stop All` button.
   - <img width="191" alt="image" src="https://github.com/user-attachments/assets/20bc378c-4255-41a2-95d0-a579b6f5f5b6">
   - <img width="569" alt="image" src="https://github.com/user-attachments/assets/9099c4bc-b96f-47b5-9038-6fab6773b571">

## Example Use Case

Let's say you are a sound designer working on a game with hundreds of sound effects. You need to quickly review a large number of sound effects without the hassle of creating game objects or scripts for each sound.

### Without This Tool:
- You would need to manually assign each audio file to an `AudioSource` in a scene.
- You'd have to hit play and test them one by one.
- If you had to test many files, this process would become very time-consuming.

### With This Tool:
- Load all audio files from a specific folder with one click.
- Quickly listen to each sound effect directly in the editor.
- Easily loop or stop sounds as needed for quick iteration.

This tool is especially useful when you are managing many sound assets or need to quickly review and sort through them.

## How It Works

1. The tool uses Unity's `EditorWindow` class to create a custom window in the editor.
2. When you select a folder, the script uses `AssetDatabase.FindAssets` to find all audio clips (`t:AudioClip`) in that folder.
3. Clips are displayed in a scrollable list, where you can play, loop, or remove them.
4. Playback is handled by dynamically creating an `AudioSource` in the editor (which is hidden from the hierarchy view).

## Known Limitations

- **Only works in the Unity Editor**: This tool is specifically designed to aid developers during the development process and will not work in a built version of the game.
- **Large folders may cause performance issues**: If you load a folder with a very large number of audio clips, the editor may slow down. It is recommended to organize audio files into manageable folders.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
