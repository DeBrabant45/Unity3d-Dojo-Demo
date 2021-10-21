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
            if (!controller.Animations.IsAnimatorBusy())
            {
                controller.Animations.SetBoolForAnimation("IsStunned", true);
            }
        }
    }
}