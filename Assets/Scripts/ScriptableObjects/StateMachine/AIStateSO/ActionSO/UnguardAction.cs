using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Unguard")]
    public class UnguardAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.Animations.AnimatorService.GetAnimationBool(controller.Combat.Weapon.BlockStanceAnimation)
                && !controller.BaseStats.Stamina.IsRegenerating
                && controller.Combat.BlockAttack != false)
            {
                Unguard(controller);
            }
        }

        private void Unguard(AIStateController controller)
        {
            controller.Combat.BlockAttack.IsBlocking = false;
            controller.Animations.AnimatorService.SetBoolForAnimation(controller.Combat.Weapon.BlockStanceAnimation, false);
        }
    }
}
