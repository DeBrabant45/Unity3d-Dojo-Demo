using UnityEngine;

namespace AD.UI
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