using AD.Interfaces;
using System;
using UnityEngine;

namespace AD.Agent
{
    public class AgentTakeDamage : MonoBehaviour, IHittable
    {
        private BlockAttack _blockAttack;
        private HurtEmissions _hurtEmissions;
        private AgentHealth _agentHealth;

        private void Start()
        {
            _blockAttack = GetComponent<BlockAttack>();
            _agentHealth = GetComponent<AgentHealth>();
            _hurtEmissions = GetComponent<HurtEmissions>();
        }

        public void GetHit(IDamage damage)
        {
            if (_blockAttack != null && _blockAttack.IsBlockHitSuccessful() != false)
            {
                return;
            }
            else
            {
                _agentHealth.ReduceHealth(damage.Amount);
                _hurtEmissions.StartHurtCoroutine();
            }
        }
    }
}
