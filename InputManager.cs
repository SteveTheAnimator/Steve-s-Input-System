using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public event Action<KeyCode> OnKeyDown;
    public event Action<KeyCode> OnKeyUp;
    public event Action<KeyCode> OnKey;

    public event Action<int> OnMouseButtonDown;
    public event Action<int> OnMouseButtonUp;
    public event Action<Vector2> OnMouseMove;

    public event Action<string> OnGamepadButtonDown;
    public event Action<string> OnGamepadButtonUp;
    public event Action<Vector2> OnGamepadMove;

#if ENABLE_VR
    public event Action<string> OnVRButtonDown;
    public event Action<string> OnVRButtonUp;
    public event Action<Vector2> OnVRMove;
#endif

    public bool LogActions = false;
    public bool xrEnabled = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CheckXREnabled();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        HandleKeyboardInput();
        HandleMouseInput();
        HandleGamepadInput();
        if (xrEnabled)
        {
            HandleVRInput();
        }
    }

    void HandleKeyboardInput()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                OnKeyDown?.Invoke(keyCode);
                Log(keyCode + " key pressed down");
            }
            if (Input.GetKeyUp(keyCode))
            {
                OnKeyUp?.Invoke(keyCode);
                Log(keyCode + " key released");
            }
            if (Input.GetKey(keyCode))
            {
                OnKey?.Invoke(keyCode);
                Log(keyCode + " key held down");
            }
        }
    }

    void HandleMouseInput()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Input.GetMouseButtonDown(i))
            {
                OnMouseButtonDown?.Invoke(i);
                Log("Mouse button " + i + " pressed down");
            }
            if (Input.GetMouseButtonUp(i))
            {
                OnMouseButtonUp?.Invoke(i);
                Log("Mouse button " + i + " released");
            }
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX != 0 || mouseY != 0)
        {
            Vector2 mouseMovement = new Vector2(mouseX, mouseY);
            OnMouseMove?.Invoke(mouseMovement);
            Log("Mouse moved: " + mouseMovement);
        }
    }

    void HandleGamepadInput()
    {
        string[] gamepadButtons = { "Jump", "Fire1", "Fire2", "Fire3" };
        foreach (var button in gamepadButtons)
        {
            if (Input.GetButtonDown(button))
            {
                OnGamepadButtonDown?.Invoke(button);
                Log("Gamepad button " + button + " pressed down");
            }
            if (Input.GetButtonUp(button))
            {
                OnGamepadButtonUp?.Invoke(button);
                Log("Gamepad button " + button + " released");
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector2 gamepadMovement = new Vector2(horizontal, vertical);
            OnGamepadMove?.Invoke(gamepadMovement);
            Log("Gamepad movement: " + gamepadMovement);
        }
    }

    void HandleVRInput()
    {
        Type inputDevicesType = Type.GetType("UnityEngine.XR.InputDevices, UnityEngine.XRModule");
        if (inputDevicesType != null)
        {
            MethodInfo getDevicesMethod = inputDevicesType.GetMethod("GetDevices");
            if (getDevicesMethod != null)
            {
                List<UnityEngine.XR.InputDevice> vrDevices = new List<UnityEngine.XR.InputDevice>();
                getDevicesMethod.Invoke(null, new object[] { vrDevices });

                foreach (var device in vrDevices)
                {
                    // Handle common VR controller inputs
                    bool primaryButtonPressed;
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryButtonPressed) && primaryButtonPressed)
                    {
                        OnVRButtonDown?.Invoke(device.name + " primaryButton");
                        Log("VR primaryButton pressed down on " + device.name);
                    }

                    bool secondaryButtonPressed;
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out secondaryButtonPressed) && secondaryButtonPressed)
                    {
                        OnVRButtonDown?.Invoke(device.name + " secondaryButton");
                        Log("VR secondaryButton pressed down on " + device.name);
                    }

                    bool triggerPressed;
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerPressed) && triggerPressed)
                    {
                        OnVRButtonDown?.Invoke(device.name + " triggerButton");
                        Log("VR triggerButton pressed down on " + device.name);
                    }

                    bool gripPressed;
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripPressed) && gripPressed)
                    {
                        OnVRButtonDown?.Invoke(device.name + " gripButton");
                        Log("VR gripButton pressed down on " + device.name);
                    }

                    Vector2 primary2DAxis;
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2DAxis) && primary2DAxis != Vector2.zero)
                    {
                        OnVRMove?.Invoke(primary2DAxis);
                        Log("VR primary2DAxis moved on " + device.name + ": " + primary2DAxis);
                    }
                }
            }
        }
    }

    void CheckXREnabled()
    {
        xrEnabled = Type.GetType("UnityEngine.XR.InputDevices, UnityEngine.XRModule") != null;
    }

    void Log(string message)
    {
        if (LogActions)
        {
            try
            {
                Debug.Log(message);
            }
            catch { }
        }
    }
}
