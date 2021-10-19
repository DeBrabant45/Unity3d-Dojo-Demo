using AD.General;
using UnityEngine;

namespace AD.UI
{
    public class UIWinFade : MonoBehaviour
    {
        private DefeatObjective _defeatObjective;
        private UINextSceneFade _nextSceneFade;

        private void Start()
        {
            _defeatObjective = FindObjectOfType<DefeatObjective>();
            _nextSceneFade = GetComponentInChildren<UINextSceneFade>();
            _defeatObjective.OnComplete += EnableFadeEffect;
        }

        public void EnableFadeEffect()
        {
            _nextSceneFade.FadeBackGround.enabled = true;
        }
    }
}