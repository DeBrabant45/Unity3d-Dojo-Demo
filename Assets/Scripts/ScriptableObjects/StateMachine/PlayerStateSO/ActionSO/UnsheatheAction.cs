using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Unsheathe Sword")]
    public class UnsheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsRKeyPressed() && !controller.AgentAnimations.IsInteracting())
            {
                controller.AgentAnimations.SetTriggerForAnimation(controller.Weapon.UnsheatheAnimation);
                controller.AgentAnimations.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
            }
        }
    }
}
