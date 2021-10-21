using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Right")]
    public class RollRightAction : Dodge
    {
        private Vector2 _movingRight = new Vector2(1.0f, 0.0f);

        public override void Direction(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.MovementInputVector == _movingRight)
            {
                base.ReduceStamina(controller);
                RollRight(controller);
            }
        }

        private void RollRight(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation("RollRight");
        }
    }
}