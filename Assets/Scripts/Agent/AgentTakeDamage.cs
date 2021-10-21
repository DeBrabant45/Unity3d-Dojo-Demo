using AD.Interfaces;
using AD.Sound;
using System;
using UnityEngine;

namespace AD.Agent
{
    public class AgentTakeDamage : MonoBehaviour, IHittable
    {
        [SerializeField] private CharacterVoice _characterVoice;

        private AgentStats _agentStats;
        private BlockAttack _blockAttack;
        private HurtEmissions _hurtEmissions;
        private AudioFX _audioFX;

        private void Start()
        {
            _blockAttack = GetComponent<BlockAttack>();
            _agentStats = GetComponent<AgentStats>();
            _hurtEmissions = GetComponent<HurtEmissions>();
            _audioFX = GetComponent<AudioFX>();
        }

        public void GetHit(IDamage damage)
        {
            if (_blockAttack == null || _blockAttack.IsBlockHitSuccessful() == false)
            {
                _agentStats.Health.ReduceAmount(damage.Amount);
                _audioFX.PlayOneShotAtRandomIndex(damage.ContactSounds);
                _audioFX.PlayOneShotAtRandomIndex(_characterVoice.HurtVoices);
                _hurtEmissions.StartHurtCoroutine();
            }
        }
    }
}
