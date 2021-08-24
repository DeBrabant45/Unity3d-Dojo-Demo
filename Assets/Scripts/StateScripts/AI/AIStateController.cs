using AD.AI.Stats;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AD.StateMachine.AI;
using AD.Interfaces;
using AD.Animation;
using AD.Weapons;

namespace AD.StateMachine.AI
{
    public class AIStateController : MonoBehaviour, IHittable
    {
        [SerializeField] private AIState _currentState;
        [SerializeField] private AIState _remainState;
        [SerializeField] private AIStats _aIStats;
        [SerializeField] private Transform _eyeSight;
        [SerializeField] private bool _aiActive = false;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private WeaponSO _weapon;

        private NavMeshAgent _navMeshAgent;
        private float _stateTimeElapsed;
        private HumanoidAnimations _animations;

        public List<Transform> wayPointList;
        public int nextWayPoint;
        public Transform ChaseTarget;
        public bool IsWeaponEquipped = false;

        public NavMeshAgent NavMeshAgent { get => _navMeshAgent; }
        public Transform EyeSight { get => _eyeSight; }
        public LayerMask Layer { get => _layer; }
        public AIStats AIStats { get => _aIStats; }
        public HumanoidAnimations Animations { get => _animations; }
        public WeaponSO Weapon { get => _weapon; }

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animations = GetComponent<HumanoidAnimations>();
        }

        private void SetupAI()
        {
            if(_aiActive != false)
            {
                _navMeshAgent.enabled = true;
            }
            else
            {
                _navMeshAgent.enabled = false;
            }
        }

        private void Update()
        {
            if(_aiActive == false)
            {
                return;
            }
            _currentState.UpdateState(this);
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
            throw new NotImplementedException();
        }
    }
}
