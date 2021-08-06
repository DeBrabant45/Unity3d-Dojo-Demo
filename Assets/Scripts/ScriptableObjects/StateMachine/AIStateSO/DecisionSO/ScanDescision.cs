using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Scan")]
    public class ScanDescision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            bool isNoTargetInSight = Scan(controller);
            return isNoTargetInSight;
        }

        private bool Scan(AIStateController controller)
        {
            controller.NavMeshAgent.isStopped = true;
            controller.transform.Rotate(0, controller.AIStats.SearchingTurnSpeed * Time.deltaTime, 0);
            return controller.CheckIfCountDownElapsed(controller.AIStats.SearchDuration);
        }
    }
}
