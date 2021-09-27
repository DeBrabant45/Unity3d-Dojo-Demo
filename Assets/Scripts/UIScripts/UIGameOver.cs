using AD.Agent;
using AD.Scene;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Button _continue;
        [SerializeField] private Button _quit;
        [SerializeField] private AgentStats _playerStats;

        private LevelManager _levelManager;

        private void Start()
        {
            _gameOverPanel.SetActive(false);
            _playerStats.Health.OnAmountEqualsZero += DisplayGameOver;
            _continue.onClick.AddListener(OnContinueClicked);
            _quit.onClick.AddListener(OnQuitClicked);
            _levelManager = FindObjectOfType<LevelManager>();
        }

        private void DisplayGameOver()
        {
            _gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        private void OnContinueClicked()
        {
            _levelManager.LoadLevel(1);
        }

        private void OnQuitClicked()
        {
            _levelManager.LoadLevel(0);
        }
    }
}