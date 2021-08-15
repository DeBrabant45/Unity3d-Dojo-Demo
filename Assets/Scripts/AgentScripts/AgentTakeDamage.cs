using AD.Interfaces;
using UnityEngine;

namespace AD.Agent
{
    public class AgentTakeDamage : MonoBehaviour, IHittable
    {
        private AgentHealth _agentHealth;

        private void Start()
        {
            _agentHealth = GetComponent<AgentHealth>();
        }

        public void GetHit(IDamage damage)
        {
            _agentHealth.ReduceHealth(damage.Amount);
        }
    }
}
