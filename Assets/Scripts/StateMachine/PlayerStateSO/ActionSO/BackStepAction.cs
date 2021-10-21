using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Back Step")]
    public class BackStepAction : Dodge
    {
        private Vector2 _notMoving = new Vector2(0.0f, 0.0f);

        public override void Direction(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.MovementInputVector == _notMoving)
            {
                base.ReduceStamina(controller);
                BackStep(controller);
            }
        }

        private void BackStep(PlayerStateController controller)
        {
            controller.Animations.SetTriggerForAnimation("BackStep");
        }
    }
}