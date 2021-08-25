using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/Sheathe Sword")]
    public class SheatheAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.InputFromPlayer.IsRKeyPressed() && !controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.SheatheAnimation);
                controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, false);
            }
        }
    }
}
