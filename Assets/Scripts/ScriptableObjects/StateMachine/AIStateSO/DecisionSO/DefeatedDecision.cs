using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Defeated")]
    public class DefeatedDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            return controller.BaseStats.Health.Amount <= 0;
        }
    }
}