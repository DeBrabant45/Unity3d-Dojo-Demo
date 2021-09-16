using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIOptionsMenu : MonoBehaviour
    {
        [SerializeField] Button _movementBtn;
        [SerializeField] Button _combatBtn;
        [SerializeField] Button _backBtn;

        [SerializeField] GameObject _movementPanel;
        [SerializeField] GameObject _combatPanel;
        [SerializeField] GameObject _previousPanel;

        void Start()
        {
            _movementPanel.SetActive(true);
            _combatPanel.SetActive(false);
            _movementBtn.onClick.AddListener(OnMovementPanel);
            _combatBtn.onClick.AddListener(OnCombatPanel);
            _backBtn.onClick.AddListener(OnBackToPreviousPanel);
        }

        private void OnBackToPreviousPanel()
        {
            _previousPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }

        private void OnCombatPanel()
        {
            _movementPanel.SetActive(false);
            _combatPanel.SetActive(true);
        }

        private void OnMovementPanel()
        {
            _movementPanel.SetActive(true);
            _combatPanel.SetActive(false);
        }
    }
}