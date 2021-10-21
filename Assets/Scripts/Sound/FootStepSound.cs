using UnityEngine;

namespace AD.Sound
{
    public class FootStepSound : MonoBehaviour
    {
        
        [SerializeField] private AudioClip _footStepClip;
        private AudioSource _footStepAudioSource;

        void Start()
        {
            _footStepAudioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot()
        {
            _footStepAudioSource.PlayOneShot(_footStepClip);
        }
    }
}