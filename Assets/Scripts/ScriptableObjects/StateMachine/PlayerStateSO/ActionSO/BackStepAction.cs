using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Back Step")]
    public class BackStepAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSpacebarPressed() && !controller.Animations.IsAnimatorBusy())
            {
                BackStep(controller);
            }
        }

        private void BackStep(PlayerStateController controller)
        {
            Vector2 notMoving = new Vector2(0.0f, 0.0f);
            if (controller.InputFromPlayer.MovementInputVector == notMoving)
            {
                controller.Animations.SetTriggerForAnimation("BackStep");
            }
        }
    }
}