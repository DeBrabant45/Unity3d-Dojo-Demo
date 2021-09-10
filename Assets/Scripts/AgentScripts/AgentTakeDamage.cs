using AD.Interfaces;
using System;
using UnityEngine;

namespace AD.Agent
{
    public class AgentTakeDamage : MonoBehaviour, IHittable
    {
        private AgentStats _agentStats;
        private BlockAttack _blockAttack;
        private HurtEmissions _hurtEmissions;

        private void Start()
        {
            _blockAttack = GetComponent<BlockAttack>();
            _agentStats = GetComponent<AgentStats>();
            _hurtEmissions = GetComponent<HurtEmissions>();
        }

        public void GetHit(IDamage damage)
        {
            if (_blockAttack == null || _blockAttack.IsBlockHitSuccessful() == false)
            {
                _agentStats.Health.ReduceAmount(damage.Amount);
                _hurtEmissions.StartHurtCoroutine();
            }
        }
    }
}
