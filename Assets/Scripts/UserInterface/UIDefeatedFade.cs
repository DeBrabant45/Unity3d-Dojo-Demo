using AD.Agent;
using UnityEngine;

namespace AD.UI
{
    public class UIDefeatedFade : MonoBehaviour
    {
        private AgentStats _playerStats;
        private UINextSceneFade _nextSceneFade;

        private void Start()
        {
            _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<AgentStats>();
            _nextSceneFade = GetComponentInChildren<UINextSceneFade>();
            _playerStats.Health.OnAmountEqualsZero += EnableFadeEffect;
        }

        public void EnableFadeEffect()
        {
            _nextSceneFade.FadeBackGround.enabled = true;
        }
    }
}