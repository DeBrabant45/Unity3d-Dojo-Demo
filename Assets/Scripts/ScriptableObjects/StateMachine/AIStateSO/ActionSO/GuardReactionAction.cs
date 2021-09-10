using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/GuardReaction")]
    public class GuardReactionAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.Combat.BlockAttack.IsBlockHitSuccessful())
            {
                GuardReaction(controller);
            }
        }

        private void GuardReaction(AIStateController controller)
        {
            controller.Combat.BlockAttack.AttackerTag = null;
            controller.Animations.AnimatorService.SetTriggerForAnimation("GuardReaction");
            controller.BaseStats.Posture.IncreaseDamage(10f);
        }
    }
}
