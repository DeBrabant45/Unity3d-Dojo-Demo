using System;
using UnityEngine;

namespace AD.Interfaces
{
    public interface IDamageable
    {
        void SetDamage(IDamage damage);
        void DoDamage(Collider collider);
    }
}