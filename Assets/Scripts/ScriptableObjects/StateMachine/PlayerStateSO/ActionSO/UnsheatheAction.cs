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
            if (controller.InputFromPlayer.IsShiftKeyPressed() && !controller.AgentAnimations.IsInteracting())
            {
                controller.AgentAnimations.SetTriggerForAnimation("equipItem");
                controller.AgentAnimations.SetBoolForAnimation("IsArmed", true);
            }
        }
    }
}
