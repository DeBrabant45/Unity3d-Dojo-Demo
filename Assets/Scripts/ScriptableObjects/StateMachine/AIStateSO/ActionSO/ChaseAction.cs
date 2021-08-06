using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Chase")]
    public class ChaseAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            Chase(controller);
        }

        private void Chase(AIStateController controller)
        {
            controller.NavMeshAgent.destination = controller.ChaseTarget.position;
            controller.NavMeshAgent.isStopped = false;
        }
    }
}
