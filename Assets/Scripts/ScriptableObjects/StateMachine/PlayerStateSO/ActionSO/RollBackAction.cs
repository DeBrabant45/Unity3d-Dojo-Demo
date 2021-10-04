using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Back")]
    public class RollBackAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.Animations.IsAnimatorBusy())
            {
                RollBack(controller);
            }
        }

        private void RollBack(PlayerStateController controller)
        {
            Vector2 movingBackwards = new Vector2(0.0f, -1.0f);
            if (controller.InputFromPlayer.MovementInputVector == movingBackwards)
            {
                controller.Animations.SetTriggerForAnimation("RollBack");
            }
        }
    }
}
