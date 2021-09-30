using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Unsheathe Sword")]
    public class UnsheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsRKeyPressed() && !controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                Unsheathe(controller);
            }
        }

        private void Unsheathe(PlayerStateController controller)
        {
            controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.UnsheatheAnimation);
            controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
        }
    }
}
