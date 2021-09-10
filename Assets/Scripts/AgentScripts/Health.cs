using System;
using AD.Interfaces;
using UnityEngine;

namespace AD.BaseStats
{
    public class Health : IHealth
    {
        private int _initialAmount;
        private float _currentAmount;

        public Health(int initialAmount)
        {
            _initialAmount = initialAmount;
            Amount = _initialAmount;
        }

        public float Amount
        {
            get => _currentAmount;
            set => _currentAmount = Mathf.Clamp(value, 0, _initialAmount);
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