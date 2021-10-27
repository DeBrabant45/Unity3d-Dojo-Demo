using System;
using AD.Interfaces;
using UnityEngine;

namespace AD.BaseStats
{
    public class Health : IHealth
    {
        private int _initialAmount;
        private float _currentAmount;

        public Action<float> OnAmountChange { get; set; }
        public Action OnAmountEqualsZero { get; set; }
        public float Amount
        {
            get => _currentAmount;
            set
            {
                _currentAmount = Mathf.Clamp(value, 0, _initialAmount);
                OnAmountChange?.Invoke(_currentAmount / _initialAmount);
                if (_currentAmount <= 0)
                {
                    OnAmountEqualsZero?.Invoke();
                }
            }
        }

        public Health(int initialAmount)
        {
            _initialAmount = initialAmount;
            Amount = _initialAmount;
        }

        public void AddAmount(float amount)
        {
            Amount += amount;
        }

        public void ReduceAmount(float amount)
        {
            Amount -= amount;
        }
    }
}