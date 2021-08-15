using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Back Step")]
    public class BackStepAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.AgentAnimations.IsInteracting())
            {
                BackStep(controller);
            }
        }

        private void BackStep(PlayerStateController controller)
        {
            controller.AgentAnimations.SetTriggerForAnimation("BackStep");
        }
    }
}
