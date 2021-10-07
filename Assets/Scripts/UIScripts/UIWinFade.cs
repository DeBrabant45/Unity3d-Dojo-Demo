using AD.General;
using UnityEngine;

namespace AD.UI
{
    public class UIWinFade : MonoBehaviour
    {
        [SerializeField] private DefeatObjective _defeatObjective;
        private UINextSceneFade _nextSceneFade;

        private void Start()
        {
            _nextSceneFade = GetComponentInChildren<UINextSceneFade>();
            _defeatObjective.OnComplete += EnableFadeEffect;
        }

        public void EnableFadeEffect()
        {
            _nextSceneFade.FadeBackGround.enabled = true;
        }
    }
}