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
        [SerializeField] private int _attackNumber;

        public Transform ChaseTarget;
        public bool IsWeaponEquipped { get; set; }
        public float AttackWaitRate { get; set; }
        public WeaponSO Weapon { get => _weapon; }
        public LayerMask TargetLayer { get => _targetLayer; }
        public BlockAttack BlockAttack { get; private set; }
        public ItemSlot ItemSlot { get; private set; }
        public int AttackNumber { get => _attackNumber; }

        void Start()
        {
            IsWeaponEquipped = false;
            BlockAttack = GetComponent<BlockAttack>();
            ItemSlot = GetComponent<ItemSlot>();
        }
    }
}