using System.Collections;
using UnityEngine;

namespace AD.Sound
{
    [CreateAssetMenu(menuName = "Sounds/Weapon/Effects")]
    public class WeaponSound : ScriptableObject
    {
        [SerializeField] private AudioClip[] _swingSounds;
        [SerializeField] private AudioClip[] _blockSounds;
        [SerializeField] private AudioClip[] _hitSounds;
        [SerializeField] private AudioClip[] _sheathSounds;
        [SerializeField] private AudioClip[] _unsheathSounds;

        public AudioClip[] SwingSounds { get => _swingSounds; set => _swingSounds = value; }
        public AudioClip[] BlockSounds { get => _blockSounds; set => _blockSounds = value; }
        public AudioClip[] HitSounds { get => _hitSounds; set => _hitSounds = value; }
        public AudioClip[] SheathSounds { get => _sheathSounds; set => _sheathSounds = value; }
        public AudioClip[] UnsheathSounds { get => _unsheathSounds; set => _unsheathSounds = value; }
    }
}