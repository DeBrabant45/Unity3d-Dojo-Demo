using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Unarmed")]
    public class UnarmedStanceDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.InputFromPlayer.IsShiftKeyPressed();
        }
    }
}
