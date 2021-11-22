using AD.Scene;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playBtn;
        [SerializeField] private Button _optionsBtn;
        [SerializeField] private Button _quitBtn;
        [SerializeField] private GameObject _optionsPanel;
        [SerializeField] private AudioSource _playButtonSound;
        private UINextSceneFade _nextSceneFade;

        private void Start()
        {
            _playBtn.onClick.AddListener(OnPlayClicked);
            _optionsBtn.onClick.AddListener(OnOptionsClicked);
            _quitBtn.onClick.AddListener(OnQuitClicked);
            _nextSceneFade = FindObjectOfType<UINextSceneFade>();
        }

        private void OnQuitClicked()
        {
            Application.Quit();
        }

        private void OnOptionsClicked()
        {
            _optionsPanel.SetActive(true);
        }

        private void OnPlayClicked()
        {
            _playButtonSound.Play();
            _nextSceneFade.FadeBackGround.enabled = true;
        }
    }
}
