using System;
using AD.Decision;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [Serializable]
    public class PlayerTransition : Transition<PlayerStateController>
    {
        [SerializeField] private PlayerDecision _decision;
        [SerializeField] private PlayerState _trueState;
        [SerializeField] private PlayerState _falseState;

        public override Decision<PlayerStateController> Decision { get => _decision; }
        public PlayerState TrueState { get => _trueState; set => _trueState = value; }
        public PlayerState FalseState { get => _falseState; set => _falseState = value; }

        public PlayerTransition(PlayerDecision playerDecision, PlayerState trueState, PlayerState falseState)
        {
            _decision = playerDecision;
            _trueState = trueState;
            _falseState = falseState;
        }
    }
}
