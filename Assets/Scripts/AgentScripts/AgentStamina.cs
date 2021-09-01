using System.Collections;
using UnityEngine;
using AD.Interfaces;
using AD.Agent;

namespace AD.Agent
{
    public class AgentStamina : MonoBehaviour
    {
        [SerializeField] private int _initialValue;
        [SerializeField] private float _regenSpeed;
        [SerializeField] private float _regenAmount;

        public IStamina Stamina { get; set; }

        private void Awake()
        {
            if (Stamina == null)
            {
                Stamina = new Stamina(_initialValue, _regenSpeed, _regenAmount);
            }
        }

        private void Update()
        {
            Stamina.SetTimePassed(Time.deltaTime);
            Stamina.StaminaRegeneration();
        }
    }
}