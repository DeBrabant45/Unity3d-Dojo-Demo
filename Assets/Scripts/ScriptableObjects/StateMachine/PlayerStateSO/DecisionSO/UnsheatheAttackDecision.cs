using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Unsheathe Attack")]
    public class UnsheatheAttackDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.InputFromPlayer.IsPrimaryAction() && controller.AgentStamina.Stamina > 0;
        }
    }
}
