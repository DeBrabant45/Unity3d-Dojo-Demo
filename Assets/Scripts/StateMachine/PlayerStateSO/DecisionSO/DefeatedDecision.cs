using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Defeated")]
    public class DefeatedDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.BaseStats.Health.Amount <= 0;
        }
    }
}
