using UnityEngine.UI;
using UnityEngine;
using AD.Player;
using AD.General;

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
        private PlayerInput _playerInput;

        void Start()
        {
            _menuPanel.SetActive(false);
            _continue.onClick.AddListener(OnContinueClicked);
            _options.onClick.AddListener(OnOptionsClicked);
            _quit.onClick.AddListener(OnQuitClicked);
            _playerInput = FindObjectOfType<PlayerInput>();
        }

        public void SetMenuPanelActive()
        {
            _menuPanel.SetActive(true);
            PauseGame.Instance.Pause();
        }

        private void OnContinueClicked()
        {
            _menuPanel.SetActive(false);
            PauseGame.Instance.Unpause();
        }

        private void OnOptionsClicked()
        {
            _menuPanel.SetActive(false);
            _optionsPanel.SetActive(true);
        }

        private void OnQuitClicked()
        {
            _menuPanel.SetActive(false);
            _quitPanel.SetActive(true);
        }

        private void Update()
        {
            if (_playerInput.IsEscapeKeyPressed())
            {
                SetMenuPanelActive();
            }
        }
    }
}