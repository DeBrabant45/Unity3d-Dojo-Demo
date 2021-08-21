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
            if (controller.InputFromPlayer.IsSecondaryHeldDownAction() != false 
                & !controller.AgentAnimations.IsInteracting())
            {
                Block(controller);
            }
            if (controller.InputFromPlayer.IsSecondaryHeldDownAction() == false
                & controller.BlockAttack.IsBlocking)
            {
                controller.BlockAttack.IsBlocking = false;
                controller.AgentAnimations.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, false);
            }
        }

        private void Block(PlayerStateController controller)
        {
            if(!controller.BlockAttack.IsBlocking)
            {
                controller.BlockAttack.IsBlocking = true;
                controller.AgentAnimations.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, true);
            }
        }
    }
}