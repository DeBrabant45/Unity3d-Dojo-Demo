using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Left")]
    public class RollLeftAction : Dodge
    {
        private Vector2 _movingLeft = new Vector2(-1.0f, 0.0f);

        public override void Direction(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.MovementInputVector == _movingLeft)
            {
                base.ReduceStamina(controller);
                RollLeft(controller);
            }
        }

        private void RollLeft(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation("RollLeft");
        }
    }
}
