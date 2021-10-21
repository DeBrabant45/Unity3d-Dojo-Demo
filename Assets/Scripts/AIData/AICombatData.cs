using AD.Weapons;
using UnityEngine;

namespace AD.AI.Data
{
    [CreateAssetMenu(menuName = "AI/Data/Combat")]
    public class AICombatData : ScriptableObject
    {
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private WeaponSO _weapon;
        [SerializeField] private int _attackNumber;

        public LayerMask TargetLayer { get => _targetLayer; }
        public WeaponSO Weapon { get => _weapon; }
        public int AttackNumber { get => _attackNumber; }
    }
}
