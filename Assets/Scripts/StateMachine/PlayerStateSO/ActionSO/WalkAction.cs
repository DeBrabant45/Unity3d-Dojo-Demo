using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Walk")]
    public class WalkAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            Walk(controller);
        }

        private void Walk(PlayerStateController controller)
        {
            HandleMovement(controller);
            HandleCameraDirection(controller);
        }

        public void HandleCameraDirection(PlayerStateController controller)
        {
            controller.Movement.HandleMovementDirection(controller.InputFromPlayer.MovementDirectionVector);
        }

        public void HandleMovement(PlayerStateController controller)
        {
            controller.Movement.HandleMovement(controller.InputFromPlayer.MovementInputVector);
        }
    }
}