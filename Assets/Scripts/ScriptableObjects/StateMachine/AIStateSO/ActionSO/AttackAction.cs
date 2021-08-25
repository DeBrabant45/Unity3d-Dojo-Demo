using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Attack")]
    public class AttackAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.Animations.AnimatorService.GetAnimationBool("IsInteracting") == false)
            {
                Attack(controller);
            }
        }

        private void Attack(AIStateController controller)
        {
            bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 5, controller.Layer);
            bool isTargetInAttackRange = Physics.CheckSphere(controller.transform.position, 2, controller.Layer);

            if(isTargetInSightRange != false && isTargetInAttackRange != false)
            {
                controller.transform.LookAt(controller.ChaseTarget);
                controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.AttackTriggerAnimation);
            }
        }
    }
}
