using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Guard")]
    public class GuardDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            return controller.AgentStamina.Stamina.IsRegenerating;
        }
    }
}
