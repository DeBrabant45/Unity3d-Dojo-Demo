using AD.Agent;
using UnityEngine;

namespace AD.UI
{
    public class UIDisableHUD : MonoBehaviour
    {
        private AgentStats _playerStats;
        
        void Start()
        {
            this.gameObject.SetActive(true);
            _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<AgentStats>();
            _playerStats.Health.OnAmountEqualsZero += Disable;
        }

        private void Disable()
        {
            this.gameObject.SetActive(false);
        }
    }
}