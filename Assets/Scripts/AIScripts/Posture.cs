using System.Collections;
using UnityEngine;

namespace AD.AI
{
    public class Posture : MonoBehaviour
    {
        [SerializeField] private float _maxAmount;
        [SerializeField] private float _regenAmount;
        private float _currentAmount;
        private bool _isPostureBroken = false;

        public bool IsPostureBroken { get => _isPostureBroken; }
        public float Amount
        {
            get => _currentAmount;
            private set => _currentAmount = Mathf.Clamp(value, 0, _maxAmount);
        }

        public void AddPostureDamage(float amount)
        {
            Amount += amount;
            if (Amount >= _maxAmount)
            {
                _isPostureBroken = true;
            }
        }

        public void RemovePostureDamage()
        {
            Amount -= _regenAmount * Time.deltaTime;
            if (Amount <= 0)
            {
                _isPostureBroken = false;
            }
        }
    }
}