using System;
using UnityEngine;

namespace AD.General
{
    public class DefeatObjective : MonoBehaviour
    {
        [SerializeField] private int _amountToWin;
        private int _currentAmount = 0;
        public Action OnComplete { get; set; }

        private void Start()
        {
            ObjectiveEvent.Instance.OnEnemyDefeated += AddAmount;
        }

        private void AddAmount()
        {
            _currentAmount++;
            EvaluateAmount();
        }

        private void EvaluateAmount()
        {
            if (_currentAmount >= _amountToWin)
            {
                OnComplete?.Invoke();
            }
        }
    }
}