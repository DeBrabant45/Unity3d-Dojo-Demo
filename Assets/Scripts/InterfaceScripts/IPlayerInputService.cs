﻿using UnityEngine;

namespace AD.Interfaces
{
    public interface IPlayerInputService
    {
        bool GetKeyButtonPressedDown(KeyCode keyCode);
        bool GetMouseuButtonPressedDown(int value);
        bool GetMouseButtonUp(int value);
        float GetAxisRaw(string value);
    }
}
