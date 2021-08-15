using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Armed")]
    public class ArmedStanceDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.InputFromPlayer.IsRKeyPressed();
        }
    }
}