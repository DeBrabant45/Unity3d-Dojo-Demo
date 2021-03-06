using System;
using UnityEngine;
using AD.Interfaces;

namespace AD.Player
{
    public class UnityInputService : IUnityInputService
    {
        public float GetAxisRaw(string value)
        {
            return Input.GetAxisRaw(value);
        }

        public bool GetKeyButtonPressedDown(KeyCode keyCode)
        {
            return Input.GetKeyDown(keyCode);
        }

        public bool GetMouseButtonUp(int value)
        {
            return Input.GetMouseButtonUp(value);
        }

        public bool GetMouseButtonPressedDown(int value)
        {
            return Input.GetMouseButtonDown(value);
        }

        public bool GetMouseButton(int value)
        {
            return Input.GetMouseButton(value);
        }

        public bool GetAxisRawPressedDown(string value)
        {
            return (GetAxisRaw(value) >= 1f) ? true : false;
        }
    }
}
