using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/GuardReaction")]
    public class GuardReactionAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.BlockAttack.IsBlockHitSuccessful())
            {
                GuardReaction(controller);
            }
        }

        private void GuardReaction(AIStateController controller)
        {
            controller.BlockAttack.AttackerTag = null;
            controller.Animations.SetTriggerForAnimation("GuardReaction");
            controller.AudioFX.PlayOneShotAtRandomIndex(controller.CombatData.Weapon.WeaponSounds.BlockSounds);
            controller.BaseStats.Posture.IncreaseDamage(controller.CombatData.Weapon.BlockPostureCost);
        }
    }
}
