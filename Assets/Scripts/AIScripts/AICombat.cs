using AD.Weapons;
using System.Collections;
using UnityEngine;

namespace AD.AI
{
    public class AICombat : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private WeaponSO _weapon;

        public Transform ChaseTarget;
        public bool IsWeaponEquipped { get; set; }
        public float AttackWaitRate { get; set; }
        public WeaponSO Weapon { get => _weapon; }
        public LayerMask TargetLayer { get => _targetLayer; }

        void Start()
        {
            IsWeaponEquipped = false;
        }
    }
}