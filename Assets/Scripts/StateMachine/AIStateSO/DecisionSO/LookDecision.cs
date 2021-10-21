using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Look")]
    public class LookDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            return IsTargetVisable(controller);
        }

        private bool IsTargetVisable(AIStateController controller)
        {
            bool isPlayerInSightRange = Physics.CheckSphere(controller.transform.position, controller.MovementData.SightRange, controller.CombatData.TargetLayer);
            return isPlayerInSightRange;
        }
    }
}
