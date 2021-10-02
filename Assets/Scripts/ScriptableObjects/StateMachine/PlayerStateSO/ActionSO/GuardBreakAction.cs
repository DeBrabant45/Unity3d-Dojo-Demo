using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/GuardBreak")]
    public class GuardBreakAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.BaseStats.Posture.IsBroken)
            {
                GuardBreak(controller);
            }
        }

        private void GuardBreak(PlayerStateController controller)
        {
            controller.BlockAttack.IsBlocking = false;
            controller.Animations.SetBoolForAnimation(controller.Weapon.BlockStanceAnimation, false);
            controller.Animations.SetTriggerForAnimation("GuardBreak");
        }
    }
}