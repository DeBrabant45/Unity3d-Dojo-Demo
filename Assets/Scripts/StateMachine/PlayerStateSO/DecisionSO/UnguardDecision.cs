using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Unguard")]
    public class UnguardDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.BlockAttack.IsBlocking == false && controller.BaseStats.Posture.IsBroken == false;
        }
    }
}
