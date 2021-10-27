using AD.Agent;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIPlayerPosture : MonoBehaviour
    {
        [SerializeField] private Image _postureBar;
        [SerializeField] private Text _percent;
        [SerializeField ]private AgentStats _agentStats;

        private void Start()
        {
            _agentStats.Posture.OnAmountChange += SetCurrentPosture;
        }

        public void SetCurrentPosture(float amount)
        {
            var amountPercent = Convert.ToInt32(amount * 100f);
            _postureBar.transform.localScale = new Vector3(Mathf.Clamp01(amount), 1, 1);
            _percent.text = amountPercent.ToString() + " %";
        }
    }
}