using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Back Step")]
    public class BackStepAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed())
            {
                BackStep(controller);
            }
        }

        private void BackStep(PlayerStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy())
            {
                controller.Animations.SetTriggerForAnimation("BackStep");
            }
        }
    }
}
