using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Chase")]
    public class ChaseAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy())
            {
                Chase(controller);
            }
        }

        private void Chase(AIStateController controller)
        {
            controller.Movement.SetDestination(controller.Combat.ChaseTarget.position);
        }
    }
}
