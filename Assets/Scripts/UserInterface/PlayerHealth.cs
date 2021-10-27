using AD.Agent;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private Text _percent;
        [SerializeField] private AgentStats _agentStats;

        private void Start()
        {
            _agentStats.Health.OnAmountChange += SetCurrentHealth;
        }

        public void SetCurrentHealth(float amount)
        {
            var amountPercent = Convert.ToInt32(amount * 100f);
            _healthBar.transform.localScale = new Vector3(Mathf.Clamp01(amount), 1, 1);
            _percent.text = amountPercent.ToString() + " %";
        }
    }
}