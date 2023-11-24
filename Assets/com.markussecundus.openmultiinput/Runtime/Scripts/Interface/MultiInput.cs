using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiInput : ScriptableObject
{
    [SerializeField] int MouseIndex;
    [SerializeField] int KeyboardIndex;

    IMouse _mouse => IInputProvider.Instance.ActiveMice.ElementAt(MouseIndex);
    IKeyboard _keyboard => IInputProvider.Instance.ActiveKeyboards.ElementAt(KeyboardIndex);


    public bool anyKey => _mouse.IsAnyButtonPressed || _keyboard.IsAnyButtonPressed;
    public bool anyKeyDown => _mouse.IsAnyButtonDown || _keyboard.IsAnyButtonDown;
    public bool anyKeyUp => _mouse.IsAnyButtonUp || _keyboard.IsAnyButtonUp;

    public float GetAxis(string axisName) => 0f;
    public float GetAxisRaw(string axisName) => 0f;

    public bool GetButton(string buttonName) => false;
    public bool GetButtonDown(string buttonName) => false;
    public bool GetButtonUp(string buttonName) => false;

    public bool GetKey(string keyName) => false;
    public bool GetKey(KeyCode key) => false;
    public bool GetKeyDown(string keyName) => false;
    public bool GetKeyDown(KeyCode key) => false;
    public bool GetKeyUp(string keyName) => false;
    public bool GetKeyUp(KeyCode key) => false;

    public bool GetMouseButton(int button) => false;
    public bool GetMouseButtonDown(int button) => false;
    public bool GetMouseButtonUp(int button) => false;

    public string inputString => "";
    public Vector3 mousePosition => default;
    public bool mousePresent => _mouse != null;
    public Vector2 mouseScrollDelta => default;

    public void ResetInputAxes() { }
}
