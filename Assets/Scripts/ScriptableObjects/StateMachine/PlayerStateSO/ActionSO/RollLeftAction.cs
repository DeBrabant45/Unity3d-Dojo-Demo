using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Left")]
    public class RollLeftAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.Animations.IsAnimatorBusy())
            {
                RollLeft(controller);
            }
        }

        private void RollLeft(PlayerStateController controller)
        {
            Vector2 movingLeft = new Vector2(-1.0f, 0.0f);
            if (controller.InputFromPlayer.MovementInputVector == movingLeft)
            {
                controller.Animations.SetTriggerForAnimation("RollLeft");
            }
        }
    }
}
