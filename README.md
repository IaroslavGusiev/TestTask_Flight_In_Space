# TestTask_Flight_In_Space
Fast test task: 2D game "Flight in space" (took near 14 hours). 

Using Third-Party Libraries/SDKs:
- Addressables;
- UniTask;
- VContainer; 
- DOTween; 
- Firebase Analytics;
These libraries/SDKs are already included in the project and do not need to be installed separately.

Special Startup Steps:
The project can be launched from any scene. However, it is recommended to switch to the Android build target before launching the project. Additionally, in the editor, user input mimics touch controls on mobile devices (click left/right on the screen to move the ship).

The project uses the following architecture:
- The project utilizes a Composition Root with a service-based architecture, leveraging a DI Container to manage dependencies;
- UI: Lightweight MVVP;
- Some gameplay logic: lightweight MVP;
