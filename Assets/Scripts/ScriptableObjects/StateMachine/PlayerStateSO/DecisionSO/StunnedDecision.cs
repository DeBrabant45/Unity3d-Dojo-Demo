using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Stunned")]
    public class StunnedDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.BaseStats.Posture.IsBroken 
                && controller.BlockAttack.IsBlocking == false;
        }
    }
}