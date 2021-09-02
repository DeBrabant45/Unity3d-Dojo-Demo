using AD.Weapons;
using System.Collections;
using UnityEngine;
using AD.Agent;

namespace AD.AI
{
    public class AICombat : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private WeaponSO _weapon;
        private BlockAttack _blockAttack;

        public Transform ChaseTarget;
        public bool IsWeaponEquipped { get; set; }
        public float AttackWaitRate { get; set; }
        public WeaponSO Weapon { get => _weapon; }
        public LayerMask TargetLayer { get => _targetLayer; }
        public BlockAttack BlockAttack { get => _blockAttack; }

        void Start()
        {
            IsWeaponEquipped = false;
            _blockAttack = GetComponent<BlockAttack>();
        }
    }
}