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
            controller.Movement.SetDestination(controller.wayPointList[controller.nextWayPoint].position);
            if (controller.Movement.NavMeshAgent.remainingDistance <= 
                controller.Movement.NavMeshAgent.stoppingDistance 
                && !controller.Movement.NavMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
        }
    }
}
