using AD.Agent;
using System.Collections;
using UnityEngine;

namespace AD.Sound
{
    public class LoseSound : MonoBehaviour
    {
        [SerializeField] private AgentStats _playerStats;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _playerStats.Health.OnAmountEqualsZero += Play;
        }

        private void Play()
        {
            _audioSource.Play();
        }
    }
}