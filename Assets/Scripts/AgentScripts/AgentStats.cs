using AD.BaseStats;
using AD.Interfaces;
using UnityEngine;

namespace AD.Agent
{
    public class AgentStats : MonoBehaviour, IBaseStats
    {
        [SerializeField] HealthSO _healthSO;
        [SerializeField] StaminaSO _staminaSO;
        [SerializeField] PostureSO _postureSO;

        public IHealth Health { get; set; }
        public IStamina Stamina { get; set; }
        public IPosture Posture { get; set; }

        void Awake()
        {
            Health = new Health(_healthSO.InitialValue);
            Stamina = new Stamina(_staminaSO.InitialValue, _staminaSO.RegenSpeed, _staminaSO.RegenAmount);
            Posture = new Posture(_postureSO.MaxAmount, _postureSO.RegenAmount);
        }

        void Update()
        {
            Stamina.SetTimePassed(Time.deltaTime);
            Stamina.StaminaRegeneration();
        }
    }
}