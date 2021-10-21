using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Guard")]
    public class GuardAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy() && !controller.BaseStats.Posture.IsBroken)
            {
                Guard(controller);
            }
        }

        private void Guard(AIStateController controller)
        {
            if (controller.RandomRange() == 5)
            {
                controller.BlockAttack.IsBlocking = true;
                controller.Animations.SetBoolForAnimation(controller.CombatData.Weapon.BlockStanceAnimation, true);
            }
        }
    }
}