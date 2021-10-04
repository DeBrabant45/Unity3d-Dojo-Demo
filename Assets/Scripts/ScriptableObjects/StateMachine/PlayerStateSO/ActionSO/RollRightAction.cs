using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Right")]
    public class RollRightAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.Animations.IsAnimatorBusy())
            {
                RollRight(controller);
            }
        }

        private void RollRight(PlayerStateController controller)
        {
            Vector2 movingRight = new Vector2(1.0f, 0.0f);
            if (controller.InputFromPlayer.MovementInputVector == movingRight)
            {
                controller.Animations.SetTriggerForAnimation("RollRight");
            }
        }
    }
}