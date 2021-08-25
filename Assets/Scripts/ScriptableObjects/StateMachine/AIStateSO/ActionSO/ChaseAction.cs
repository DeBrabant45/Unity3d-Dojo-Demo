﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Chase")]
    public class ChaseAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                Chase(controller);
            }
        }

        private void Chase(AIStateController controller)
        {
            controller.transform.LookAt(controller.ChaseTarget);
            controller.NavMeshAgent.destination = controller.ChaseTarget.position;
            controller.NavMeshAgent.isStopped = false;
            var velcocityY = controller.NavMeshAgent.velocity.y;
            var magnitude = controller.NavMeshAgent.velocity.magnitude;
            controller.Animations.AnimatorService.SetAnimationFloat("Move", magnitude);
        }
    }
}
