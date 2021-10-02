using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Sheathe Sword")]
    public class SheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsRKeyPressed() && !controller.Animations.IsAnimatorBusy())
            {
                Sheathe(controller);
            }
        }

        private void Sheathe(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation(controller.Weapon.SheatheAnimation);
            controller.Animations.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, false);
        }
    }
}
