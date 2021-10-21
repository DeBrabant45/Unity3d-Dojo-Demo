using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Patrol")]
    class PatrolAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            Patrol(controller);
        }

        private void Patrol(AIStateController controller)
        {
            controller.Movement.SetDestination(controller.WayPoint.WayPoints[controller.WayPoint.NextWayPoint].position);
            if (controller.Movement.NavMeshAgent.remainingDistance <= 
                controller.Movement.NavMeshAgent.stoppingDistance 
                && !controller.Movement.NavMeshAgent.pathPending)
            {
                controller.WayPoint.NextWayPoint = (controller.WayPoint.NextWayPoint + 1) % controller.WayPoint.WayPoints.Count;
            }
        }
    }
}
