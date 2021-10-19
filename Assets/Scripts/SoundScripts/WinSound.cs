using AD.General;
using UnityEngine;

namespace AD.Sound
{
    public class WinSound : MonoBehaviour
    {
        private DefeatObjective _defeatObjective;
        private AudioSource _audioSource;

        private void Start()
        {
            _defeatObjective = FindObjectOfType<DefeatObjective>();
            _audioSource = GetComponent<AudioSource>();
            _defeatObjective.OnComplete += Play;
        }

        private void Play()
        {
            _audioSource.Play();
        }
    }
}