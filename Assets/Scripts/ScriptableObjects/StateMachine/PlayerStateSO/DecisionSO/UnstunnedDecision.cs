using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Unstunned")]
    public class UnstunnedDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.BaseStats.Posture.IsBroken == false
                && controller.Animations.AnimatorService.GetAnimationBool("IsStunned") == false;
        }
    }
}
