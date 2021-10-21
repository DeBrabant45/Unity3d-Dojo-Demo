using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Unguard")]
    public class UnguardAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.BaseStats.Stamina.IsRegenerating && controller.BlockAttack.IsBlocking)
            {
                Unguard(controller);
            }
        }

        private void Unguard(AIStateController controller)
        {
            if (controller.Animations.GetAnimationBool(controller.CombatData.Weapon.BlockStanceAnimation))
            {
                controller.BlockAttack.IsBlocking = false;
                controller.Animations.SetBoolForAnimation(controller.CombatData.Weapon.BlockStanceAnimation, false);
            }
        }
    }
}
