using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/LookAtTarget")]
    public class LookAtTargetAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            controller.transform.LookAt(controller.Combat.ChaseTarget);
        }
    }
}