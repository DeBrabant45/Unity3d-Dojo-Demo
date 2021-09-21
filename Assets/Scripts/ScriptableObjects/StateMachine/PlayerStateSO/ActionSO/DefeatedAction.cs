using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Defeated")]
    public class DefeatedAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.BaseStats.Health.Amount <= 0 && controller.enabled != false)
            {
                Defeated(controller);
            }
        }

        private void Defeated(PlayerStateController controller)
        {
            controller.Animations.AnimatorService.SetBoolForAnimation("IsDefeated", true);
            controller.AgentAimController.enabled = false;
            controller.enabled = false;
        }
    }
}
