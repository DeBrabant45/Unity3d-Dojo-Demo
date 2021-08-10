using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Sheathe Sword")]
    public class SheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsShiftKeyPressed() && !controller.AgentAnimations.IsInteracting())
            {
                controller.AgentAnimations.SetTriggerForAnimation("unequipItem");
                controller.AgentAnimations.SetBoolForAnimation("meleeWeaponStance", false);
            }
        }
    }
}
