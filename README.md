# LOOP//ERROR

This repository contains scripts and basic assets for the Unity psychological horror game **LOOP//ERROR**.

## Setup
1. Create a new **3D Core** project in Unity 2021 or newer.
2. Copy the contents of this repository into your project's `Assets` folder.
3. Open `Assets/Scenes/Main.unity` (create it if it does not exist) and set it as your start scene.
4. Ensure Windows build target is selected (`File > Build Settings`).
5. Play from the editor.

All visuals use Unity primitives (Cube, Plane, etc.). Audio and texture placeholders are located under `Assets/Resources`.

## Scripts
- `LoopManager.cs` – controls hallway loops and anomaly progression.
- `Anomaly.cs` – attached to objects that can appear altered.
- `AnomalyTracker.cs` – picks anomalies each loop.
- `TerminalController.cs` – handles the fake terminal game.
- `GlitchFX.cs` – manages paranoia‑induced post‑processing effects.
- `AudioManager.cs` – central audio playback.
- `PlayerController.cs` – simple WASD/Mouse look with interaction.
- `LogWriter.cs` – appends entries to `Resources/log.txt`.

## Notes
This project intentionally avoids external 3D models and uses only built‑in Unity components. Prefabs and scene objects should be wired via the inspector following comments in each script.
