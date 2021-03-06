using AD.Agent;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIPlayerStamina : MonoBehaviour
    {
        [SerializeField] private Image _staminaBar;
        [SerializeField] private Text _percent;
        [SerializeField] private AgentStats _agentStats;

        private void Start()
        {
            _agentStats.Stamina.OnAmountChange += SetCurrentStamina;
        }

        public void SetCurrentStamina(float amount)
        {
            var amountPercent = Convert.ToInt32(amount * 100f);
            _staminaBar.transform.localScale = new Vector3(Mathf.Clamp01(amount), 1, 1);
            _percent.text = amountPercent.ToString() + " %";
        }
    }
}