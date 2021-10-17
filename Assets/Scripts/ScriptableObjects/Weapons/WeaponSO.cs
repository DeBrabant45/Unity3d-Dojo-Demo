using AD.Interfaces;
using AD.Sound;
using UnityEngine;

namespace AD.Weapons
{
    [CreateAssetMenu(menuName = "Item/Weapon")]
    public class WeaponSO : ScriptableObject, IDamage
    {
        [Header("Weapon Attack Settings")]
        [SerializeField] int _minimalDamage = 0;
        [SerializeField] int _maximumDamage = 0;
        [SerializeField] [Range(0, 1)] float _criticalDamageChance = 0.2f;
        [SerializeField] float _attackStaminaCost;
        [SerializeField] float _blockPostureCost;
        [SerializeField] float _range;

        [Header("Weapon Animation Settings")]
        [SerializeField] string _attackStanceAnimation;
        [SerializeField] string _attackAnimation;
        [SerializeField] string _unsheatheAttackAnimation;
        [SerializeField] string _blockStanceAnimation;
        [SerializeField] string _blockReactionAnimation;
        [SerializeField] string _unsheatheAnimation;
        [SerializeField] string _sheatheAnimation;

        [Header("Weapon Sounds")]
        [SerializeField] WeaponSound _weaponSounds;

        [Header("Weapon particle effects")]
        [SerializeField] private GameObject _attackHitEffect;
        [SerializeField] private GameObject _attackBlockedEffect;

        public string AttackStanceAnimation { get => _attackStanceAnimation; }
        public string AttackTriggerAnimation { get => _attackAnimation; }
        public string UnsheatheAttackAnimation { get => _unsheatheAttackAnimation; }
        public string UnsheatheAnimation { get => _unsheatheAnimation; }
        public string SheatheAnimation { get => _sheatheAnimation; set => _sheatheAnimation = value; }
        public string BlockStanceAnimation { get => _blockStanceAnimation; }
        public string BlockReactionAnimation { get => _blockReactionAnimation; }
        public int Amount { get => GetDamageValue(); }
        public float AttackStaminaCost { get => _attackStaminaCost; }
        public float BlockPostureCost { get => _blockPostureCost; }
        public GameObject ParticalEffect { get => _attackHitEffect; }
        public GameObject AttackBlockedEffect { get => _attackBlockedEffect; }
        public float Range { get => _range; }
        public WeaponSound WeaponSounds { get => _weaponSounds; set => _weaponSounds = value; }
        public AudioClip[] ContactSounds { get => _weaponSounds.HitSounds; }

        public int GetDamageValue()
        {
            int randomDamge = UnityEngine.Random.Range(_minimalDamage, _maximumDamage + 1);
            var randomCriticalChance = UnityEngine.Random.value;

            if (randomCriticalChance < _criticalDamageChance)
            {
                return _maximumDamage * 2;
            }
            return randomDamge;
        }
    }
}
