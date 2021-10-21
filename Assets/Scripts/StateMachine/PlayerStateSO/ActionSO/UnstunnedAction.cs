using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Unstunned")]
    public class UnstunnedAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (!controller.BaseStats.Posture.IsBroken)
            {
                Unstunned(controller);
            }
        }

        private void Unstunned(PlayerStateController controller)
        {
            controller.Animations.SetBoolForAnimation("IsStunned", false);
        }
    }
}
