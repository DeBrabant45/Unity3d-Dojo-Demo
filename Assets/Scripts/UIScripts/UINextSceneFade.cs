using AD.Scene;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AD.UI
{
    public class UINextSceneFade : MonoBehaviour
    {
        [SerializeField] private float _fadeInTime;
        [SerializeField] private int _sceneId;
        private Color _currentColor = Color.black;
        private LevelManager _levelManager;

        public Image FadeBackGround { get; private set; }

        private void Start()
        {
            FadeBackGround = GetComponent<Image>();
            FadeBackGround.enabled = false;
            _levelManager = FindObjectOfType<LevelManager>();
            _currentColor.a = 0;
        }

        private void Update()
        {
            if (FadeBackGround.enabled == true)
            {
                StartCoroutine("BeginFadeToNextScene");
            }
        }

        public IEnumerator BeginFadeToNextScene()
        {
            FadeBackGround.enabled = true;
            FadeBackGround.color = _currentColor;
            float alphaChange = Time.deltaTime / _fadeInTime;
            _currentColor.a += alphaChange;
            yield return new WaitForSeconds(_fadeInTime);
            _levelManager.LoadLevel(_sceneId);
        }
    }
}