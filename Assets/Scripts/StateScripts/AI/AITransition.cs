using System;
using AD.Decision;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [Serializable]
    public class AITransition : Transition<AIStateController>
    {
        [SerializeField] private AIDecision _decision;
        [SerializeField] private AIState _trueState;
        [SerializeField] private AIState _falseState;

        public override Decision<AIStateController> Decision => _decision;
        public AIState TrueState { get => _trueState; }
        public AIState FalseState { get => _falseState;  }
    }
}
