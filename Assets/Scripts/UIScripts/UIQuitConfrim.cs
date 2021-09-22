using AD.Scene;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIQuitConfrim : MonoBehaviour
    {
        [SerializeField] Button _yesBtn;
        [SerializeField] Button _noBtn;
        [SerializeField] GameObject _confirmPanel;
        [SerializeField] GameObject _previousPanel;
        private LevelManager _levelManager;

        public void Start()
        {
            _levelManager = FindObjectOfType<LevelManager>();
            _yesBtn.onClick.AddListener(OnYesClicked);
            _noBtn.onClick.AddListener(OnNoClicked);
        }

        private void OnNoClicked()
        {
            _confirmPanel.SetActive(false);
            _previousPanel.SetActive(true);
        }

        private void OnYesClicked()
        {
            Time.timeScale = 1;
            _levelManager.LoadLevel(0);
        }
    }
}
