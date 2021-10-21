using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Sound
{
    [CreateAssetMenu(menuName = "Sounds/Character/Voices")]
    public class CharacterVoice : ScriptableObject
    {
        [SerializeField] private AudioClip[] _hurtVoices;
        [SerializeField] private AudioClip[] _attackVoices;
        [SerializeField] private AudioClip[] _defeatedVoices;

        public AudioClip[] HurtVoices { get => _hurtVoices; set => _hurtVoices = value; }
        public AudioClip[] AttackVoices { get => _attackVoices; set => _attackVoices = value; }
        public AudioClip[] DefeatedVoices { get => _defeatedVoices; set => _defeatedVoices = value; }
    }
}