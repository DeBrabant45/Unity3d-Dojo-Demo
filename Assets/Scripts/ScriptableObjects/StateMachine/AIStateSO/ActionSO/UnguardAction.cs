using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Unguard")]
    public class UnguardAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.BaseStats.Stamina.IsRegenerating && controller.Combat.BlockAttack.IsBlocking)
            {
                Unguard(controller);
            }
        }

        private void Unguard(AIStateController controller)
        {
            if (controller.Animations.GetAnimationBool(controller.Combat.Weapon.BlockStanceAnimation))
            {
                controller.Combat.BlockAttack.IsBlocking = false;
                controller.Animations.SetBoolForAnimation(controller.Combat.Weapon.BlockStanceAnimation, false);
            }
        }
    }
}
