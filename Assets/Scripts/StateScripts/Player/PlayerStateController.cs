﻿using AD.Agent;
using AD.Animation;
using AD.Interfaces;
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
        [SerializeField] private WeaponSO _equippedWeapon;

        private AgentMovement _movement;
        private AgentAimController _agentAimController;
        private PlayerInput _inputFromPlayer;
        private HumanoidAnimations _agentAnimations;
        private AgentHealth _agentHealth;
        private AgentStamina _agentStamina;
        private ItemSlot _itemSlot;

        public PlayerInput InputFromPlayer { get => _inputFromPlayer; }
        public AgentMovement Movement { get => _movement; }
        public HumanoidAnimations AgentAnimations { get => _agentAnimations; }
        public AgentAimController AgentAimController { get => _agentAimController; }
        public ItemSlot ItemSlot { get => _itemSlot; }
        public WeaponSO EquippedWeapon { get => _equippedWeapon; }
        public string TagName { get => this.tag; }
        public AgentStamina AgentStamina { get => _agentStamina; }

        private void Awake()
        {
            _movement = GetComponent<AgentMovement>();
            _inputFromPlayer = GetComponent<PlayerInput>();
            _agentAnimations = GetComponent<HumanoidAnimations>();
            _itemSlot = GetComponent<ItemSlot>();
            _agentAimController = GetComponent<AgentAimController>();
            _itemSlot = GetComponent<ItemSlot>();
            _agentHealth = GetComponent<AgentHealth>();
            _agentStamina = GetComponent<AgentStamina>();
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
            Debug.Log(_agentStamina.Stamina);
        }

        public void TransitionToState(PlayerState nextState)
        {
            if (nextState != _remainState)
            {
                _currentState = nextState;
                _currentState.EnterState(this);
            }
        }
    }
}
