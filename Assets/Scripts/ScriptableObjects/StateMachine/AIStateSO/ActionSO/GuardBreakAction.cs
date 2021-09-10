using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/GuardBreak")]
    public class GuardBreakAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.BaseStats.Posture.IsBroken)
            {
                GuardBreak(controller);
            }
        }

        private void GuardBreak(AIStateController controller)
        {
            controller.Combat.BlockAttack.IsBlocking = false;
            controller.Animations.AnimatorService.SetBoolForAnimation(controller.Combat.Weapon.BlockStanceAnimation, false);
            controller.Animations.AnimatorService.SetTriggerForAnimation("GuardBreak");
        }
    }
}
