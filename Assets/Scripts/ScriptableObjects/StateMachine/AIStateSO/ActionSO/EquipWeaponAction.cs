using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/EquipWeapon")]
    public class EquipWeaponAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if(!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            {
                EquipWeapon(controller);
            }
        }

        private void EquipWeapon(AIStateController controller)
        {
            if(!controller.Combat.IsWeaponEquipped)
            {
                bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 20, controller.Combat.TargetLayer);
                if (isTargetInSightRange != false)
                {
                    controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Combat.Weapon.UnsheatheAnimation);
                    controller.Animations.AnimatorService.SetBoolForAnimation(controller.Combat.Weapon.AttackStanceAnimation, true);
                    controller.Combat.IsWeaponEquipped = true;
                }
            }
        }
    }
}
