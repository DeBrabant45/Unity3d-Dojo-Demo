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
            controller.NavMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            controller.NavMeshAgent.isStopped = false;

            if (controller.NavMeshAgent.remainingDistance <= 
                controller.NavMeshAgent.stoppingDistance && !controller.NavMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
        }
    }
}
