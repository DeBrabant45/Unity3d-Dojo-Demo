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
            if (!controller.Animations.IsAnimatorBusy()
                && IsAbleToAttack(controller))
            {
                Attack(controller);
            }
        }

        private bool IsAbleToAttack(AIStateController controller)
        {
            return (!controller.BaseStats.Stamina.IsRegenerating
                && controller.Combat.AttackWaitRate > 1f
                && controller.RandomRange() == controller.Combat.AttackNumber) ? true : false;
        }

        private void Attack(AIStateController controller)
        {
            if (IsTargetInSightRange(controller) && IsTargetInAttackRange(controller))
            {
                controller.Combat.AttackWaitRate = 0;
                SetItemSlotDamage(controller);
                controller.transform.LookAt(controller.Combat.ChaseTarget);
                controller.Animations.SetTriggerForAnimation(controller.Combat.Weapon.AttackTriggerAnimation);
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

        private void SetItemSlotDamage(AIStateController controller)
        {
            controller.Combat.ItemSlot.DamageCollider.SetDamage(controller.Combat.Weapon);
            controller.Combat.ItemSlot.DamageCollider.SetTagToNotHit(controller);
        }
    }
}