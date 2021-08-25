using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Block")]
    public class BlockAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSecondaryActionPressed() != false 
                & !controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                Block(controller);
            }
            if (controller.InputFromPlayer.IsSecondaryActionPressed() == false
                & controller.BlockAttack.IsBlocking)
            {
                controller.BlockAttack.IsBlocking = false;
                controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, false);
            }
        }

        private void Block(PlayerStateController controller)
        {
            if(!controller.BlockAttack.IsBlocking)
            {
                controller.BlockAttack.IsBlocking = true;
                controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, true);
            }
        }
    }
}