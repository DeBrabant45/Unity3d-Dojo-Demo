using AD.Agent;
using UnityEngine;

namespace AD.UI
{
    public class UIDefeatedFade : MonoBehaviour
    {
        [SerializeField] private AgentStats _playerStats;
        private UINextSceneFade _nextSceneFade;

        private void Start()
        {
            _nextSceneFade = GetComponentInChildren<UINextSceneFade>();
            _playerStats.Health.OnAmountEqualsZero += EnableFadeEffect;
        }

        public void EnableFadeEffect()
        {
            _nextSceneFade.FadeBackGround.enabled = true;
        }
    }
}