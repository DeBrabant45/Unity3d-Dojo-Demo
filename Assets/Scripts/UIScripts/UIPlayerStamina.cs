using AD.Agent;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIPlayerStamina : MonoBehaviour
    {
        [SerializeField] private Image _staminaBar;
        [SerializeField] private AgentStats _agentStats;

        private void Start()
        {
            _agentStats.Stamina.OnAmountChange += SetCurrentStamina;
        }

        public void SetCurrentStamina(float amount)
        {
            _staminaBar.transform.localScale = new Vector3(Mathf.Clamp01(amount), 1, 1);
        }
    }
}