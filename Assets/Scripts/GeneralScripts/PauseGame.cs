using System;
using UnityEngine;

namespace AD.General
{
    public class PauseGame : MonoBehaviour
    {
        public static PauseGame Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            Instance = this;
            Unpause();
        }

        public void Pause()
        {
            AudioListener.volume = 0.5f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            AudioListener.volume = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
