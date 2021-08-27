using UnityEngine;

namespace AD.Interfaces
{
    public interface IUnityInputService
    {
        bool GetKeyButtonPressedDown(KeyCode keyCode);
        bool GetMouseButtonPressedDown(int value);
        bool GetMouseButton(int value);
        bool GetMouseButtonUp(int value);
        bool GetAxisRawPressedDown(string value);
        float GetAxisRaw(string value);
    }
}
