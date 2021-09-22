using UnityEngine.UI;
using UnityEngine;

namespace AD.UI
{
    public class UIPauseMenu : MonoBehaviour
    {
        [SerializeField] GameObject _menuPanel;
        [SerializeField] Button _continue;
        [SerializeField] Button _options;
        [SerializeField] Button _quit;

        [SerializeField] GameObject _optionsPanel;
        [SerializeField] GameObject _quitPanel;

        void Start()
        {
            _menuPanel.SetActive(false);
            _continue.onClick.AddListener(OnContinue);
            _options.onClick.AddListener(OnOptions);
            _quit.onClick.AddListener(OnQuit);
        }

        public void SetMenuPanelActive()
        {
            _menuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        private void OnContinue()
        {
            _menuPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }

        private void OnOptions()
        {
            _menuPanel.SetActive(false);
            _optionsPanel.SetActive(true);
        }

        private void OnQuit()
        {
            _menuPanel.SetActive(false);
            _quitPanel.SetActive(true);
        }
    }
}