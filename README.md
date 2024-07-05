# Steve's Input Manager

A custom input manager for Unity that supports keyboard, mouse, gamepad, and VR controller inputs without using Unity's built-in Input System.

## Features

- **Keyboard Input:** Detects key down, key up, and key held events for all keys.
- **Mouse Input:** Detects mouse button presses, releases, and movement.
- **Gamepad Input:** Detects button presses, releases, and joystick movement.
- **VR Input (Optional):** Automatically detects VR controllers if VR support is present in the project, handling common VR inputs like buttons and thumbstick movements.

## Installation

1. **Download the Package:**
   Download the package from this repository.

2. **Import Package into your Unity Project:**
    Import the Package by right clicking your project and clicking `Import Package/Custom Package`

3. **Add InputManager to Scene:**
   Attach the `InputManager` script to a GameObject in your scene. It is recommended to create an empty GameObject called "InputManager" and attach the script to it.

4. **Enable VR Support (Optional):**
   If you want to use VR controller input, ensure you have the XR Interaction Toolkit and any specific VR SDKs (e.g., OpenXR, Oculus XR Plugin) installed via the Unity Package Manager.

## Usage

### InputManager

The `InputManager` handles all input detection and provides events for various input actions.

#### Events

- **Keyboard Events:**
  - `OnKeyDown(KeyCode keyCode)`
  - `OnKeyUp(KeyCode keyCode)`
  - `OnKey(KeyCode keyCode)`

- **Mouse Events:**
  - `OnMouseButtonDown(int button)`
  - `OnMouseButtonUp(int button)`
  - `OnMouseMove(Vector2 movement)`

- **Gamepad Events:**
  - `OnGamepadButtonDown(string button)`
  - `OnGamepadButtonUp(string button)`
  - `OnGamepadMove(Vector2 movement)`

- **VR Events (if VR support is available):**
  - `OnVRButtonDown(string button)`
  - `OnVRButtonUp(string button)`
  - `OnVRMove(Vector2 movement)`

#### Properties

- `bool LogActions`: If set to `true`, logs all input actions to the console.

#### Example

```csharp
using UnityEngine;

public class Sample : MonoBehaviour
{
    public GameObject InputManagerGameobject;
    private InputManager InputM;

    void OnEnable()
    {
        InputM = InputManagerGameobject.GetComponent<InputManager>();
        if (InputM != null)
        {
            InputM.OnKeyDown += HandleKeyDown;
            InputM.OnKeyUp += HandleKeyUp;
            InputM.OnKey += HandleKey;

            InputM.OnMouseButtonDown += HandleMouseButtonDown;
            InputM.OnMouseButtonUp += HandleMouseButtonUp;
            InputM.OnMouseMove += HandleMouseMove;

            InputM.OnGamepadButtonDown += HandleGamepadButtonDown;
            InputM.OnGamepadButtonUp += HandleGamepadButtonUp;
            InputM.OnGamepadMove += HandleGamepadMove;

            if (InputM.xrEnabled)
            {
                InputM.OnVRButtonDown += HandleVRButtonDown;
                InputM.OnVRButtonUp += HandleVRButtonUp;
                InputM.OnVRMove += HandleVRMove;
            }
        }
        else
        {
            Debug.LogWarning("InputManager instance is null. Make sure InputManager script is attached to a GameObject in the scene.");
        }
    }

    void OnDisable()
    {
        if (InputM != null)
        {
            InputM.OnKeyDown -= HandleKeyDown;
            InputM.OnKeyUp -= HandleKeyUp;
            InputM.OnKey -= HandleKey;

            InputM.OnMouseButtonDown -= HandleMouseButtonDown;
            InputM.OnMouseButtonUp -= HandleMouseButtonUp;
            InputM.OnMouseMove -= HandleMouseMove;

            InputM.OnGamepadButtonDown -= HandleGamepadButtonDown;
            InputM.OnGamepadButtonUp -= HandleGamepadButtonUp;
            InputM.OnGamepadMove -= HandleGamepadMove;

            if (InputM.xrEnabled)
            {
                InputM.OnVRButtonDown -= HandleVRButtonDown;
                InputM.OnVRButtonUp -= HandleVRButtonUp;
                InputM.OnVRMove -= HandleVRMove;
            }
        }
    }

    void HandleKeyDown(KeyCode keyCode)
    {
        Debug.Log("Key down: " + keyCode);
        // Add your custom logic for key down event
    }

    void HandleKeyUp(KeyCode keyCode)
    {
        Debug.Log("Key up: " + keyCode);
        // Add your custom logic for key up event
    }

    void HandleKey(KeyCode keyCode)
    {
        Debug.Log("Key held: " + keyCode);
        // Add your custom logic for key held event
    }

    void HandleMouseButtonDown(int button)
    {
        Debug.Log("Mouse button down: " + button);
        // Add your custom logic for mouse button down event
    }

    void HandleMouseButtonUp(int button)
    {
        Debug.Log("Mouse button up: " + button);
        // Add your custom logic for mouse button up event
    }

    void HandleMouseMove(Vector2 movement)
    {
        Debug.Log("Mouse move: " + movement);
        // Add your custom logic for mouse move event
    }

    void HandleGamepadButtonDown(string button)
    {
        Debug.Log("Gamepad button down: " + button);
        // Add your custom logic for gamepad button down event
    }

    void HandleGamepadButtonUp(string button)
    {
        Debug.Log("Gamepad button up: " + button);
        // Add your custom logic for gamepad button up event
    }

    void HandleGamepadMove(Vector2 movement)
    {
        Debug.Log("Gamepad move: " + movement);
        // Add your custom logic for gamepad move event
    }

    void HandleVRButtonDown(string button)
    {
        Debug.Log("VR button down: " + button);
        // Add your custom logic for VR button down event
    }

    void HandleVRButtonUp(string button)
    {
        Debug.Log("VR button up: " + button);
        // Add your custom logic for VR button up event
    }

    void HandleVRMove(Vector2 movement)
    {
        Debug.Log("VR move: " + movement);
        // Add your custom logic for VR move event
    }
}

