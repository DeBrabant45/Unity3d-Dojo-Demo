using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Stunned")]
    public class StunnedDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            return controller.Combat.AIPosture.IsPostureBroken;
        }
    }
}