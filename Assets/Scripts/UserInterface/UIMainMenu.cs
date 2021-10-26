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
        [SerializeField] private AudioSource _playButtonClicked;
        private UINextSceneFade _nextSceneFade;

        private void Start()
        {
            _playBtn.onClick.AddListener(OnPlayClicked);
            _optionsBtn.onClick.AddListener(OnOptionsClicked);
            _nextSceneFade = FindObjectOfType<UINextSceneFade>();
        }

        private void OnOptionsClicked()
        {
            _optionsPanel.SetActive(true);
        }

        private void OnPlayClicked()
        {
            _playButtonClicked.Play();
            _nextSceneFade.FadeBackGround.enabled = true;
        }
    }
}
