using System;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/GuardReaction")]
    public class GuardReactionAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (controller.BlockAttack.IsBlockHitSuccessful())
            {
                GuardReaction(controller);
            }
        }

        private void GuardReaction(PlayerStateController controller)
        {
            controller.BlockAttack.AttackerTag = null;
            controller.AudioFX.PlayOneShotAtRandomIndex(controller.Weapon.WeaponSounds.BlockSounds);
            controller.Animations.SetTriggerForAnimation("GuardReaction");
            controller.BaseStats.Posture.IncreaseDamage(controller.Weapon.BlockPostureCost);
        }
    }
}