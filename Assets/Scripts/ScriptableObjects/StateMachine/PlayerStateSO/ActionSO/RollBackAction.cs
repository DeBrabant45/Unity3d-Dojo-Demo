using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Roll Back")]
    public class RollBackAction : Dodge
    {
        private Vector2 _movingBackwards = new Vector2(0.0f, -1.0f);

        public override void Direction(PlayerStateController controller)
        {

            if (controller.InputFromPlayer.MovementInputVector == _movingBackwards)
            {
                base.ReduceStamina(controller);
                RollBack(controller);
            }
        }

        private void RollBack(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation("RollBack");
        }
    }
}
