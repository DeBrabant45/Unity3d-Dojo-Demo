using AD.Agent;
using AD.General;
using UnityEngine;

namespace AD.UI
{
    public class UIDisableHUD : MonoBehaviour
    {
        [SerializeField] private AgentStats _playerStats;
        private DefeatObjective _objective;
        
        void Start()
        {
            this.gameObject.SetActive(true);
            _objective = FindObjectOfType<DefeatObjective>();
            _playerStats.Health.OnAmountEqualsZero += Disable;
            _objective.OnComplete += Disable;
        }

        private void Disable()
        {
            this.gameObject.SetActive(false);
        }
    }
}