using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Guard")]
    public class GuardAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsSecondaryActionPressed() != false 
                & !controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                Guard(controller);
            }
        }

        private void Guard(PlayerStateController controller)
        {
            if(!controller.BlockAttack.IsBlocking)
            {
                controller.BlockAttack.IsBlocking = true;
                controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, true);
            }
        }
    }
}