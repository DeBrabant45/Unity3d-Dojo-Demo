using AD.Agent;
using UnityEngine;

namespace AD.UI
{
    public class UIDisableHUD : MonoBehaviour
    {
        [SerializeField] AgentStats _playerStats;
        
        void Start()
        {
            this.gameObject.SetActive(true);
            _playerStats.Health.OnAmountEqualsZero += Disable;
        }

        private void Disable()
        {
            this.gameObject.SetActive(false);
        }
    }
}