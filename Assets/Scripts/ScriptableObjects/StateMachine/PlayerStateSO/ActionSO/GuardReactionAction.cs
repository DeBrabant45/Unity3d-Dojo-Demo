using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/GuardReaction")]
    public class GuardReactionAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.BlockAttack.IsBlockHitSuccessful())
            {
                GuardReaction(controller);
            }
        }

        private void GuardReaction(PlayerStateController controller)
        {
            controller.BlockAttack.AttackerTag = null;
            controller.Animations.AnimatorService.SetTriggerForAnimation("GuardReaction");
            controller.BaseStats.Posture.IncreaseDamage(10f);
        }
    }
}