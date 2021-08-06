using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/State")]
    public class PlayerState : State<PlayerStateController>
    {
        [SerializeField] private PlayerAction[] _nonUpdateActions;
        [SerializeField] private PlayerAction[] _actions;
        [SerializeField] private PlayerTransition[] _transitions;
        public Color sceneGizmoColor = Color.grey;

        public void EnterState(PlayerStateController controller)
        {
            for (int i = 0; i < _nonUpdateActions.Length; i++)
            {
                _nonUpdateActions[i].Act(controller);
            }
        }

        public override void CheckTransitions(PlayerStateController controller)
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

        public override void DoActions(PlayerStateController controller)
        {
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Act(controller);
            }
        }

        public override void UpdateState(PlayerStateController controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }
    }
}
