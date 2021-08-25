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
            if(!controller.IsWeaponEquipped)
            {
                bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 20, controller.Layer);
                if (isTargetInSightRange != false)
                {
                    controller.Animations.AnimatorService.SetTriggerForAnimation(controller.Weapon.UnsheatheAnimation);
                    controller.Animations.AnimatorService.SetBoolForAnimation(controller.Weapon.AttackStanceAnimation, true);
                    controller.IsWeaponEquipped = true;
                }
            }
        }
    }
}
