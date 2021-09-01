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
            if(controller.InputFromPlayer.IsPrimaryActionPressed())
            {
                Attack(controller);
            }
        }

        private void Attack(PlayerStateController controller)
        {
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting") && controller.AgentStamina.Stamina.Amount > 0)
            {
                controller.ItemSlot.DamageCollider.SetDamage(controller.Weapon);
                controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
                controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.AttackTriggerAnimation);
                controller.AgentStamina.Stamina.ReduceStamina(controller.Weapon.StaminaCost);
            }
        }
    }
}