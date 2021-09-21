using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Unguard")]
    public class UnguardAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            Unguard(controller);
        }

        private void Unguard(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSecondaryActionPressed() == false & controller.BlockAttack.IsBlocking)
            {
                controller.BlockAttack.IsBlocking = false;
                controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, false);
            }
        }
    }
}
