using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Attack")]
    public class AttackAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            Attack(controller);
        }

        private void Attack(PlayerStateController controller)
        {
            if (Input.GetKeyDown(KeyCode.T) && controller.IsInteracting == false)
            {
                controller.ItemSlot.DamageCollider.SetDamage(controller.EquippedWeapon);
                controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
                controller.AgentAnimations.SetTriggerForAnimation("OneHandedAttack");
                //controller.AgentStamina.ReduceStamina(10);
            }
        }
    }
}