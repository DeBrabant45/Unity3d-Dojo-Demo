using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Unsheathe Sword")]
    public class UnsheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsRKeyPressed() && !controller.Animations.IsAnimatorBusy())
            {
                Unsheathe(controller);
            }
        }

        private void Unsheathe(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation(controller.Weapon.UnsheatheAnimation);
            controller.Animations.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
        }
    }
}