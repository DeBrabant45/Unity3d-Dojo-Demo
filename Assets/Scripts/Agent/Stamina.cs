using System;
using UnityEngine;
using AD.Interfaces;

namespace AD.Agent
{
    public class Stamina : IStamina
    {
        private int _initialAmount;
        private float _regenSpeed;
        private float _regenAmount;

        private float _currentAmount;
        private float _lastTimeSinceStaminaChange;
        private bool _isRegenerating = false;
        private float _timePassed;

        public bool IsRegenerating { get => _isRegenerating; }
        public Action<float> OnAmountChange { get; set; }
        public float Amount
        {
            get => _currentAmount;
            set
            {
                _currentAmount = Mathf.Clamp(value, 0, _initialAmount);
                OnAmountChange?.Invoke(_currentAmount / _initialAmount);
            }
        }

        public Stamina(int startAmount, float regenSpeed, float regenAmount)
        {
            _initialAmount = startAmount;
            _regenSpeed = regenSpeed;
            _regenAmount = regenAmount;
            Amount = _initialAmount;
        }

        public void AddToStamina(float amount)
        {
            Amount += amount;
        }

        public void ReduceStamina(float amount)
        {
            Amount -= amount;
            _lastTimeSinceStaminaChange = _timePassed;
        }

        public void SetTimePassed(float amount)
        {
            _timePassed += amount;
        }

        public void StaminaRegeneration()
        {
            if (Amount < _initialAmount && (_lastTimeSinceStaminaChange + _regenSpeed) < _timePassed)
            {
                Amount += _regenAmount;
                if (Amount == _initialAmount)
                {
                    _isRegenerating = false;
                }
            }
            if (Amount <= 0)
            {
                _isRegenerating = true;
            }
        }
    }
}