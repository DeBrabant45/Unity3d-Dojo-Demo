using AD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AD.Weapons
{
    [CreateAssetMenu(menuName = "Item/Weapon")]
    public class WeaponSO : ScriptableObject, IDamage
    {
        [Header("Weapon Basic Info Settings")]
        [SerializeField] private GameObject _model;

        [Header("Weapon Attack Settings")]
        [SerializeField] int _minimalDamage = 0;
        [SerializeField] int _maximumDamage = 0;
        [SerializeField] [Range(0, 1)] float _criticalDamageChance = 0.2f;
        [SerializeField] WeaponType _weaponType;
        [SerializeField] float _weaponImpactForce;
        [SerializeField] int _staminaCost;
        [SerializeField] float _range;

        [Header("Weapon Animation Settings")]
        [SerializeField] string _attackStanceAnimation;
        [SerializeField] string _attackAnimation;
        [SerializeField] string _unsheatheAttackAnimation;
        [SerializeField] string _blockStanceAnimation;
        [SerializeField] string _blockReactionAnimation;
        [SerializeField] string _unsheatheAnimation;
        [SerializeField] string _sheatheAnimation;

        [Header("Weapon Equipped transform")]
        [SerializeField] Vector3 _equippedPosition;
        [SerializeField] Vector3 _equippedRotation;

        [Header("Weapon Unequipped transform")]
        [SerializeField] Vector3 _unequippedPosition;
        [SerializeField] Vector3 _unequippedRotation;

        [Header("Weapon Sounds")]
        [SerializeField] private AudioClip[] _soundClips;
        [SerializeField] private bool _isSoundRandom;

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
        public float StaminaCost { get => _staminaCost; }
        public AudioClip[] SoundClips { get => _soundClips; }
        public GameObject Model { get => _model; }
        public GameObject ParticalEffect { get => _attackHitEffect; }
        public GameObject AttackBlockedEffect { get => _attackBlockedEffect; }
        public float Range { get => _range; }

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
