using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Sheathe Sword")]
    public class SheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsRKeyPressed() && !controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                Sheathe(controller);
            }
        }

        private void Sheathe(PlayerStateController controller)
        {
            controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.SheatheAnimation);
            controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, false);
        }
    }
}
