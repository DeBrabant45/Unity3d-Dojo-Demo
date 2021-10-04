using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Forward")]
    public class RollForwardAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.Animations.IsAnimatorBusy())
            {
                RollForward(controller);
            }
        }

        private void RollForward(PlayerStateController controller)
        {
            Vector2 movingForward = new Vector2(0.0f, 1.0f);
            if (controller.InputFromPlayer.MovementInputVector == movingForward)
            {
                controller.Animations.SetTriggerForAnimation("RollForward");
            }
        }
    }
}