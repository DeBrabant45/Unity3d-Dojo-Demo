using AD.Agent;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UIPlayerPosture : MonoBehaviour
    {
        [SerializeField] private Image _postureBar;
        private AgentStats _agentStats;

        private void Start()
        {
            _agentStats = GameObject.FindGameObjectWithTag("Player").GetComponent<AgentStats>();
            _agentStats.Posture.OnAmountChange += SetCurrentPosture;
        }

        public void SetCurrentPosture(float amount)
        {
            _postureBar.transform.localScale = new Vector3(Mathf.Clamp01(amount), 1, 1);
        }
    }
}