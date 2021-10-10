using AD.Sound;
using System;
using UnityEngine;

namespace AD.General
{
    public class FootCollider : MonoBehaviour
    {
        private FootStepSound _footStepSound;

        private void Start()
        {
            _footStepSound = GetComponent<FootStepSound>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Floor")
            {
                _footStepSound.PlayOneShot();
            }
        }
    }
}
