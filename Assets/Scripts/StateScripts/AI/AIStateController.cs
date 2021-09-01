using AD.AI.Stats;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AD.StateMachine.AI;
using AD.Interfaces;
using AD.Animation;
using AD.Weapons;
using AD.AI;
using AD.Agent;

namespace AD.StateMachine.AI
{
    public class AIStateController : MonoBehaviour, IHittable
    {
        [SerializeField] private AIState _currentState;
        [SerializeField] private AIState _remainState;
        [SerializeField] private AIStats _aIStats;
        [SerializeField] private Transform _eyeSight;

        private AgentStamina _stamina;
        private float _stateTimeElapsed;
        private HumanoidAnimations _animations;
        private AIMovement _movement;
        private AIWayPoint _wayPoint;
        private AICombat _combat;

        public Transform EyeSight { get => _eyeSight; }
        public AIStats AIStats { get => _aIStats; }
        public HumanoidAnimations Animations { get => _animations; }
        public AIMovement Movement { get => _movement; }
        public AgentStamina AgentStamina { get => _stamina; }
        public AIWayPoint WayPoint { get => _wayPoint; }
        public AICombat Combat { get => _combat; }

        private void Awake()
        {
            _animations = GetComponent<HumanoidAnimations>();
            _movement = GetComponent<AIMovement>();
            _stamina = GetComponent<AgentStamina>();
            _wayPoint = GetComponent<AIWayPoint>();
            _combat = GetComponent<AICombat>();
        }

        private void Update()
        {
            _currentState.UpdateState(this);
            //Debug.Log(_stamina.Stamina.Amount);
        }

        public void TransitionToState(AIState nextState)
        {
            if (nextState != _remainState)
            {
                _currentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            _stateTimeElapsed += Time.deltaTime;
            return (_stateTimeElapsed >= duration);
        }

        public int RandomRange()
        {
            return UnityEngine.Random.Range(0, 10);
        }

        private void OnExitState()
        {
            _stateTimeElapsed = 0;
        }

        public void GetHit(IDamage damage)
        {
            Debug.Log(damage.Amount);
        }
    }
}
