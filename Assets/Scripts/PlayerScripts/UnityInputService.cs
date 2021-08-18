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

        public bool GetMouseuButtonPressedDown(int value)
        {
            return Input.GetMouseButtonDown(value);
        }
    }
}
