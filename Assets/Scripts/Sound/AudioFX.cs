using System.Collections;
using UnityEngine;

namespace AD.Sound
{
    public class AudioFX : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShotAtRandomIndex(AudioClip[] audioClips)
        {
            var randomIndexInHurtClips = Random.Range(0, audioClips.Length);
            _audioSource.PlayOneShot(audioClips[randomIndexInHurtClips]);
        }

        public void PlayOneShotAtIndexZero(AudioClip[] audioClips)
        {
            _audioSource.PlayOneShot(audioClips[0]);
        }
    }
}