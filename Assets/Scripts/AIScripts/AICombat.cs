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

        public Transform ChaseTarget;
        public bool IsWeaponEquipped { get; set; }
        public float AttackWaitRate { get; set; }
        public float TickWaitRate { get; set; }
        public WeaponSO Weapon { get => _weapon; }
        public LayerMask TargetLayer { get => _targetLayer; }
        public BlockAttack BlockAttack { get; private set; }
        public Posture AIPosture { get; private set; }

        void Start()
        {
            IsWeaponEquipped = false;
            BlockAttack = GetComponent<BlockAttack>();
            AIPosture = GetComponent<Posture>();
        }
    }
}