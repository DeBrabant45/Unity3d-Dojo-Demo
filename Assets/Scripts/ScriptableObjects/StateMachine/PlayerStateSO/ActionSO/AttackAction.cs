using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Attack")]
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
            if (!controller.Animations.IsAnimatorBusy() && controller.BaseStats.Stamina.Amount > 0)
            {
                SetItemDamage(controller);
                controller.Animations.SetTriggerForAnimation(controller.Weapon.AttackTriggerAnimation);
                controller.BaseStats.Stamina.ReduceStamina(controller.Weapon.StaminaCost);
            }
        }

        private void SetItemDamage(PlayerStateController controller)
        {
            controller.ItemSlot.DamageCollider.SetDamage(controller.Weapon);
            controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
        }
    }
}