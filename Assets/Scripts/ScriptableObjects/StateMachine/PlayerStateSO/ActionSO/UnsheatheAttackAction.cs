using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Unsheathe Attack")]
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
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting") && controller.AgentStamina.Stamina.Amount > 0)
            {
                controller.ItemSlot.DamageCollider.SetDamage(controller.Weapon);
                controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
                controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.UnsheatheAttackAnimation);
                controller.AgentStamina.Stamina.ReduceStamina(controller.Weapon.StaminaCost);
                controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
            }
        }
    }
}
