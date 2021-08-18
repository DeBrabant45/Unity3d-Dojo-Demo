using UnityEngine;

namespace AD.Interfaces
{
    public interface IUnityInputService
    {
        bool GetKeyButtonPressedDown(KeyCode keyCode);
        bool GetMouseuButtonPressedDown(int value);
        bool GetMouseButtonUp(int value);
        float GetAxisRaw(string value);
    }
}
