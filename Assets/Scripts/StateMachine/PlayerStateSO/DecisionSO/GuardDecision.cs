using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Guard")]
    public class GuardDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return controller.InputFromPlayer.IsSecondaryActionPressed() != false
                & !controller.Animations.IsAnimatorBusy();
        }
    }
}
