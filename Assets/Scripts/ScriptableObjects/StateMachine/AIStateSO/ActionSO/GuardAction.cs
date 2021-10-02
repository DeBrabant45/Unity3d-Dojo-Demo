using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Guard")]
    public class GuardAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy()
                && controller.BaseStats.Stamina.IsRegenerating
                && !controller.BaseStats.Posture.IsBroken)
            {
                Guard(controller);
            }
        }

        private void Guard(AIStateController controller)
        {
            controller.Combat.BlockAttack.IsBlocking = true;
            controller.Animations.SetBoolForAnimation(controller.Combat.Weapon.BlockStanceAnimation, true);
        }
    }
}
