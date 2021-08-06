using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/State")]
    public class AIState : State<AIStateController>
    {
        [SerializeField] private AIAction[] _actions;
        [SerializeField] private AITransition[] _transitions;
        public Color sceneGizmoColor = Color.grey;

        public override void UpdateState(AIStateController controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        public override void DoActions(AIStateController controller)
        {
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Act(controller);
            }
        }

        public override void CheckTransitions(AIStateController controller)
        {
            for (int i = 0; i < _transitions.Length; i++)
            {
                bool decisionSucceeded = _transitions[i].Decision.Decide(controller);
                if (decisionSucceeded)
                {
                    controller.TransitionToState(_transitions[i].TrueState);
                }
                else
                {
                    controller.TransitionToState(_transitions[i].FalseState);
                }
            }
        }

    }
}
