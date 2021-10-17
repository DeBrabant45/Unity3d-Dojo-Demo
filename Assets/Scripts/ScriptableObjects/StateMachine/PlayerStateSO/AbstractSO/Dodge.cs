using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    public abstract class Dodge : PlayerAction
    {
        private float _staminaCost = 10f;

        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.Animations.IsAnimatorBusy())
            {
                if (controller.BaseStats.Stamina.Amount >= _staminaCost)
                {
                    Direction(controller);
                }
            }
        }

        public abstract void Direction(PlayerStateController controller);

        public virtual void ReduceStamina(PlayerStateController controller)
        {
            controller.BaseStats.Stamina.ReduceStamina(_staminaCost);
        }
    }
}
