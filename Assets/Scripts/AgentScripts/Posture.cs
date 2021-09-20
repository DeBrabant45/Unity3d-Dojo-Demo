using UnityEngine;
using AD.Interfaces;
using System;

namespace AD.Agent
{
    public class Posture : IPosture
    {
        private float _maxDamage;
        private float _regenAmount;
        private float _currentDamage;
        private bool _isBroken = false;

        public bool IsBroken { get => _isBroken; }
        public Action<float> OnAmountChange { get; set; }
        public float Damage
        {
            get => _currentDamage;
            private set
            {
                _currentDamage = Mathf.Clamp(value, 0, _maxDamage);
                OnAmountChange?.Invoke(_currentDamage);
            }
        }

        public Posture(float maxAmount, float regenAmount)
        {
            _maxDamage = maxAmount;
            _regenAmount = regenAmount;
        }

        public void IncreaseDamage(float amount)
        {
            Damage += amount;
            if (Damage >= _maxDamage)
            {
                _isBroken = true;
            }
        }

        public void ReduceDamage()
        {
            Damage -= _regenAmount * Time.deltaTime;
            if (Damage <= 0)
            {
                _isBroken = false;
            }
        }
    }
}