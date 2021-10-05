using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Roll back")]
    public class RollBackAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy() && controller.RandomRange() == 20)
            {
                RollBack(controller);
            }
        }

        private void RollBack(AIStateController controller)
        {
            controller.Animations.SetTriggerForAnimation("RollBack");
        }
    }
}
