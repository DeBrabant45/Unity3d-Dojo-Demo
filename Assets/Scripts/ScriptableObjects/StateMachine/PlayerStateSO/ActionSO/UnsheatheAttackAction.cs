using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Unsheathe Attack")]
    public class UnsheatheAttackAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsPrimaryAction() != false)
            {
                UnsheatheAttack(controller);
            }
        }

        private void UnsheatheAttack(PlayerStateController controller)
        {
            if (!controller.AgentAnimations.IsInteracting() && controller.AgentStamina.Stamina > 0)
            {
                controller.ItemSlot.DamageCollider.SetDamage(controller.Weapon);
                controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
                controller.AgentAnimations.SetTriggerForAnimation(controller.Weapon.UnsheatheAttackAnimation);
                controller.AgentStamina.ReduceStamina(controller.Weapon.StaminaCost);
                controller.AgentAnimations.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
            }
        }
    }
}
