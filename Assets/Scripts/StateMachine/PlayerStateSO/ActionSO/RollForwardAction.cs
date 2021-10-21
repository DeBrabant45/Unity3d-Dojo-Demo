using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Forward")]
    public class RollForwardAction : Dodge
    {
        private Vector2 _movingForward = new Vector2(0.0f, 1.0f);

        public override void Direction(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.MovementInputVector == _movingForward)
            {
                base.ReduceStamina(controller);
                RollForward(controller);
            }
        }

        private void RollForward(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation("RollForward");
        }
    }
}