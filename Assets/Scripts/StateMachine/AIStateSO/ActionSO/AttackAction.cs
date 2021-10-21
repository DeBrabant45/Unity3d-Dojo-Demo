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
            controller.TimeBuffer += Time.deltaTime;
            if (!controller.Animations.IsAnimatorBusy() && IsAbleToAttack(controller))
            {
                if (controller.TimeBuffer > 1f)
                {
                    Attack(controller);
                }
            }
        }

        private bool IsAbleToAttack(AIStateController controller)
        {
            return (!controller.BaseStats.Stamina.IsRegenerating
                && controller.RandomRange() == controller.CombatData.AttackNumber) ? true : false;
        }

        private void Attack(AIStateController controller)
        {
            if (IsTargetInSightRange(controller) && IsTargetInAttackRange(controller))
            {
                controller.TimeBuffer = 0;
                SetItemSlotDamage(controller);
                SetAttackSounds(controller);
                controller.transform.LookAt(controller.ChaseTarget);
                controller.Animations.SetTriggerForAnimation(controller.CombatData.Weapon.AttackTriggerAnimation);
                controller.BaseStats.Stamina.ReduceStamina(controller.CombatData.Weapon.AttackStaminaCost);
            }
        }

        private bool IsTargetInSightRange(AIStateController controller)
        {
            return Physics.CheckSphere(controller.transform.position, controller.MovementData.SightRange, controller.CombatData.TargetLayer);
        }        

        private bool IsTargetInAttackRange(AIStateController controller)
        {
            return Physics.CheckSphere(controller.transform.position, controller.CombatData.Weapon.Range, controller.CombatData.TargetLayer);
        }

        private void SetAttackSounds(AIStateController controller)
        {
            controller.AudioFX.PlayOneShotAtRandomIndex(controller.CharacterVoice.AttackVoices);
            controller.AudioFX.PlayOneShotAtRandomIndex(controller.CombatData.Weapon.WeaponSounds.SwingSounds);
        }

        private void SetItemSlotDamage(AIStateController controller)
        {
            controller.ItemSlot.DamageCollider.SetDamage(controller.CombatData.Weapon);
            controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
        }
    }
}