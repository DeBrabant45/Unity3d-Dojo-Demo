using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Unstunned")]
    public class UnstunnedAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Combat.AIPosture.IsPostureBroken)
            {
                Unstunned(controller);
            }
        }

        private void Unstunned(AIStateController controller)
        {
            controller.Animations.AnimatorService.SetBoolForAnimation("IsStunned", false);
        }
    }
}