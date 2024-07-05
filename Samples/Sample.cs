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
