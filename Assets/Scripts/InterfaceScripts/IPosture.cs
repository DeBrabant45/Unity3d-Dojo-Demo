using System;

namespace AD.Interfaces
{
    public interface IPosture
    {
        public bool IsBroken { get; }
        public float Damage { get; }
        public Action<float> OnAmountChange { get; set; }
        public void IncreaseDamage(float amount);
        public void ReduceDamage();
    }
}