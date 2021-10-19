using UnityEngine;

namespace AD.General
{
    public class UnlockCursorOnAwake : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}