using System;

namespace AD.Interfaces
{
    public interface IPosture
    {
        public bool IsBroken { get; }
        public float Damage { get; }
        public void IncreaseDamage(float amount);
        public void ReduceDamage();
    }
}