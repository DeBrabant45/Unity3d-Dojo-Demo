using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/UnequipWeapon")]
    public class UnequipWeaponAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                UnequipWeapon(controller);
            }
        }

        private void UnequipWeapon(AIStateController controller)
        {
            if (controller.Combat.IsWeaponEquipped != false)
            {
                bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 20, controller.Combat.TargetLayer);
                if (!isTargetInSightRange)
                {
                    controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Combat.Weapon.SheatheAnimation);
                    controller.Animations.AnimatorService.SetBoolForAnimation(controller.Combat.Weapon.AttackStanceAnimation, false);
                    controller.Combat.IsWeaponEquipped = false;
                }
            }
        }
    }
}
