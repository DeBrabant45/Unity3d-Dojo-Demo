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

namespace AD.StateMachine.AI
{
    public class AIStateController : MonoBehaviour, IHittable
    {
        [SerializeField] private AIState _currentState;
        [SerializeField] private AIState _remainState;
        [SerializeField] private AIStats _aIStats;
        [SerializeField] private Transform _eyeSight;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private WeaponSO _weapon;

        private float _stateTimeElapsed;
        private HumanoidAnimations _animations;
        private AIMovement _movement;

        public List<Transform> wayPointList;
        public int nextWayPoint;
        public Transform ChaseTarget;
        public bool IsWeaponEquipped = false;

        public Transform EyeSight { get => _eyeSight; }
        public LayerMask Layer { get => _layer; }
        public AIStats AIStats { get => _aIStats; }
        public HumanoidAnimations Animations { get => _animations; }
        public WeaponSO Weapon { get => _weapon; }
        public AIMovement Movement { get => _movement; }

        private void Awake()
        {
            _animations = GetComponent<HumanoidAnimations>();
            _movement = GetComponent<AIMovement>();
        }

        private void Update()
        {
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
            Debug.Log(damage.Amount);
        }
    }
}
