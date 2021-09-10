using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Attack")]
    public class AttackAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            controller.Combat.AttackWaitRate += Time.deltaTime;
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting")
                && !controller.BaseStats.Stamina.IsRegenerating && controller.Combat.AttackWaitRate > 1f)
            {
                Attack(controller);
            }
        }

        private void Attack(AIStateController controller)
        {
            if (IsTargetInSightRange(controller) && IsTargetInAttackRange(controller))
            {
                controller.Combat.AttackWaitRate = 0;
                controller.transform.LookAt(controller.Combat.ChaseTarget);
                controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Combat.Weapon.AttackTriggerAnimation);
                controller.BaseStats.Stamina.ReduceStamina(controller.Combat.Weapon.StaminaCost);
            }
        }

        private bool IsTargetInSightRange(AIStateController controller)
        {
            return Physics.CheckSphere(controller.transform.position, controller.AIStats.SightRange, controller.Combat.TargetLayer);
        }        

        private bool IsTargetInAttackRange(AIStateController controller)
        {
            return Physics.CheckSphere(controller.transform.position, controller.Combat.Weapon.Range, controller.Combat.TargetLayer);
        }
    }
}