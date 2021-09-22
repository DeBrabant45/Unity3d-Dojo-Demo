using AD.Scene;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playBtn;
        [SerializeField] private Button _optionsBtn;
        [SerializeField] private GameObject _optionsPanel;
        private LevelManager _levelManager;

        private void Start()
        {
            _playBtn.onClick.AddListener(OnPlayClicked);
            _optionsBtn.onClick.AddListener(OnOptionsClicked);
            _levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnOptionsClicked()
        {
            _optionsPanel.SetActive(true);
        }

        private void OnPlayClicked()
        {
            _levelManager.LoadNextLevel();
        }
    }
}
