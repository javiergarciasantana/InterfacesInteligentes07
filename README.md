InterfacesInteligentes07
# Microphone and Camera Integration in Unity

This repository contains two Unity scripts that demonstrate microphone recording and webcam integration for interactive applications. These scripts showcase the capture of audio and video, and provide features like real-time playback and frame capturing.

## Features
- **Scene where spiders make sound upon recolection of items(Egg.cs)**
  ![prueba arañas](https://github.com/user-attachments/assets/dbf5497e-ba82-4ac2-9cac-a062b54759f9)

- **Recorder.cs**
  - Records audio from the microphone using Unity's `Microphone` API.
  - Plays back the recorded audio in real-time.
  - Allows toggling recording with keypresses.

- **TV.cs**
  - Displays webcam feed on a material in the scene.
  - Captures and saves frames as PNG images.
  - Provides controls to start, pause, and stop video capture.

## Prerequisites

1. Unity version 2020.3 or higher.
2. A device with a working microphone and webcam.
3. Appropriate file permissions for saving images on your device.

## Setup

1. Clone this repository:
   ```bash
   git clone https://github.com/javiergarciasantana/InterfacesInteligentes07.git
   ```

2. Open the project in Unity.

3. Attach the scripts to appropriate GameObjects in your scene.

4. For the `TV` script, assign a material to the `tvMaterial` field in the Inspector.

5. Ensure the save path in the `TV` script is correct for your system.

## Script Descriptions

### `Recorder.cs`
This script captures and plays back audio input from a connected microphone:
- **AudioSource Integration**: Uses an `AudioSource` component for playback.
- **Real-Time Recording**: Records up to 10 seconds of audio and plays it in real-time.
- **Keyboard Controls**:
  - Press **R**: Start recording.
  - Release **R**: Stop recording and play the captured audio.

#### Usage
1. Attach the script to a GameObject with an `AudioSource` component.
2. Ensure a microphone is connected.
3. Press and release **R** during play mode to record and play audio.
![Prueba micro](https://github.com/user-attachments/assets/756c7435-c512-477f-af96-a17197d77bd6)

### `TV.cs`
This script integrates a webcam feed into your Unity project and captures snapshots:
- **Webcam Integration**: Displays the feed from the first available webcam.
- **Image Capture**: Saves the current frame as a PNG file.
- **Keyboard Controls**:
  - Press **S**: Start video capture.
  - Press **P**: Pause video capture.
  - Press **X**: Stop video capture.
  - Press **C**: Capture the current frame.

#### Usage
1. Attach the script to a GameObject in your scene.
2. Assign a material to the `tvMaterial` field in the Inspector.
3. Ensure the `savePath` variable is updated to a valid directory on your system.
4. Use the keyboard controls to interact with the webcam feed.
![Prueba camara2](https://github.com/user-attachments/assets/62d6d4a4-d970-4568-a126-051a56a9655d)

## Example Use Cases

- **Recorder.cs**:
  - Build voice-enabled applications.
  - Implement audio feedback features in games or simulations.

- **TV.cs**:
  - Create interactive displays or live feeds in virtual environments.
  - Capture images for augmented reality or computer vision projects.

## Troubleshooting

- **Microphone Issues**:
  - Ensure a microphone is connected and properly configured on your device.
  - Check Unity permissions for accessing the microphone.

- **Webcam Issues**:
  - Verify that a webcam is connected and available.
  - Confirm Unity permissions for accessing the camera.

- **File Saving Issues**:
  - Ensure the save path exists and has write permissions.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Feel free to open issues or contribute via pull requests to improve or expand the functionality!
