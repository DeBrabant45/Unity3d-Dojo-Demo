using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Stunned")]
    public class StunnedAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.BaseStats.Posture.IsBroken)
            {
                Stunned(controller);
            }
        }

        private void Stunned(PlayerStateController controller)
        {
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                controller.Animations.AnimatorService.SetBoolForAnimation("IsStunned", true);
            }
            controller.BaseStats.Posture.ReduceDamage();
        }
    }
}