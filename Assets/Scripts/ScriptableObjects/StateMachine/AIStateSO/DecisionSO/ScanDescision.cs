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
            return IsTargetWithinScanSight(controller);
        }

        private bool IsTargetWithinScanSight(AIStateController controller)
        {
            controller.Movement.StopMovement();
            controller.transform.Rotate(0, controller.AIStats.SearchingTurnSpeed * Time.deltaTime, 0);
            return controller.CheckIfCountDownElapsed(controller.AIStats.SearchDuration);
        }
    }
}
