using AD.Agent;
using AD.Animation;
using AD.Interfaces;
using AD.Player;
using AD.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    public class PlayerStateController : MonoBehaviour, ITagable
    {
        [SerializeField] private PlayerState _currentState;
        [SerializeField] private PlayerState _remainState;
        [SerializeField] private WeaponSO _weapon;

        public string TagName { get => this.tag; }
        public PlayerInput InputFromPlayer { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public HumanoidAnimations Animations { get; private set; }
        public PlayerAimController AgentAimController { get; private set; }
        public ItemSlot ItemSlot { get; private set; }
        public WeaponSO Weapon { get => _weapon; }
        public PlayerState CurrentState { get => _currentState; }
        public BlockAttack BlockAttack { get; private set; }
        public IBaseStats BaseStats { get; private set; }

        private void Awake()
        {
            Movement = GetComponent<PlayerMovement>();
            InputFromPlayer = GetComponent<PlayerInput>();
            Animations = GetComponent<HumanoidAnimations>();
            ItemSlot = GetComponent<ItemSlot>();
            AgentAimController = GetComponent<PlayerAimController>();
            BlockAttack = GetComponent<BlockAttack>();
            BaseStats = GetComponent<AgentStats>();
        }

        private void Update()
        {
            if (Time.timeScale == 1)
            {
                _currentState.UpdateState(this);
            }
            Debug.Log(_currentState);
        }

        public void Constructor(PlayerState currentState, PlayerState remainState, PlayerInput input)
        {
            _currentState = currentState;
            _remainState = remainState;
            InputFromPlayer = input;
        }

        public void TransitionToState(PlayerState nextState)
        {
            if (nextState != _remainState)
            {
                _currentState = nextState;
            }
        }
    }
}
