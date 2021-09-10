using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Stunned")]
    public class StunnedAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.BaseStats.Posture.IsBroken)
            {
                Stunned(controller);
            }
        }

        private void Stunned(AIStateController controller)
        {
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                controller.Animations.AnimatorService.SetBoolForAnimation("IsStunned", true);
            }
            controller.BaseStats.Posture.ReduceDamage();
        }
    }
}