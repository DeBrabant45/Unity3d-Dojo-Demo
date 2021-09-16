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

        private PlayerMovement _movement;
        private PlayerAimController _playerAimController;
        private PlayerInput _inputFromPlayer;
        private HumanoidAnimations _animations;
        private ItemSlot _itemSlot;
        private BlockAttack _blockAttack;

        public string TagName { get => this.tag; }
        public PlayerInput InputFromPlayer { get => _inputFromPlayer; }
        public PlayerMovement Movement { get => _movement; }
        public HumanoidAnimations Animations { get => _animations; }
        public PlayerAimController AgentAimController { get => _playerAimController; }
        public ItemSlot ItemSlot { get => _itemSlot; }
        public WeaponSO Weapon { get => _weapon; }
        public PlayerState CurrentState { get => _currentState; }
        public BlockAttack BlockAttack { get => _blockAttack; }
        public IBaseStats BaseStats { get; private set; }

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _inputFromPlayer = GetComponent<PlayerInput>();
            _animations = GetComponent<HumanoidAnimations>();
            _itemSlot = GetComponent<ItemSlot>();
            _playerAimController = GetComponent<PlayerAimController>();
            _itemSlot = GetComponent<ItemSlot>();
            _blockAttack = GetComponent<BlockAttack>();
            BaseStats = GetComponent<AgentStats>();
        }

        private void Update()
        {
            if (Time.timeScale == 1)
            {
                _currentState.UpdateState(this);
            }
        }

        public void Constructor(PlayerState currentState, PlayerState remainState, PlayerInput input)
        {
            _currentState = currentState;
            _remainState = remainState;
            _inputFromPlayer = input;
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
