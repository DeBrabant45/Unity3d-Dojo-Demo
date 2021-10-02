using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Unsheathe Attack")]
    public class UnsheatheAttackAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsPrimaryActionPressed() != false)
            {
                UnsheatheAttack(controller);
            }
        }

        private void UnsheatheAttack(PlayerStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy() && controller.BaseStats.Stamina.Amount > 0)
            {
                SetItemDamage(controller);
                controller.Animations.SetTriggerForAnimation(controller.Weapon.UnsheatheAttackAnimation);
                controller.BaseStats.Stamina.ReduceStamina(controller.Weapon.StaminaCost);
                controller.Animations.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
            }
        }

        private void SetItemDamage(PlayerStateController controller)
        {
            controller.ItemSlot.DamageCollider.SetDamage(controller.Weapon);
            controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
        }
    }
}
