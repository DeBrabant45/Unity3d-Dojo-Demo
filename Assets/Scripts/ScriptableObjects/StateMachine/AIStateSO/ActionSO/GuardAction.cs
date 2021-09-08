﻿using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Guard")]
    public class GuardAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting")
                && controller.AgentStamina.Stamina.IsRegenerating
                && !controller.Combat.AIPosture.IsPostureBroken)
            {
                Guard(controller);
            }
        }

        private void Guard(AIStateController controller)
        {
            controller.Combat.BlockAttack.IsBlocking = true;
            controller.Animations.AnimatorService.SetBoolForAnimation(controller.Combat.Weapon.BlockStanceAnimation, true);
        }
    }
}