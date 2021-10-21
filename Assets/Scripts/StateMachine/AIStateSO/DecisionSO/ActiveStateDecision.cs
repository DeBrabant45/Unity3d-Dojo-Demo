using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/ActiveState")]
    public class ActiveStateDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            bool isChaseTargetActive = controller.ChaseTarget.gameObject.activeSelf;
            return isChaseTargetActive;
        }
    }
}
