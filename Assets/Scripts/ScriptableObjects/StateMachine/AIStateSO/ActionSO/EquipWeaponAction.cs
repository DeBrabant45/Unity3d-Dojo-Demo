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
            if(!controller.Animations.IsAnimatorBusy())
            {
                EquipWeapon(controller);
            }
        }

        private void EquipWeapon(AIStateController controller)
        {
            if(!controller.IsWeaponEquipped)
            {
                bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 20, controller.CombatData.TargetLayer);
                if (isTargetInSightRange != false)
                {
                    controller.Animations.SetTriggerForAnimation(controller.CombatData.Weapon.UnsheatheAnimation);
                    controller.AudioFX.PlayOneShotAtRandomIndex(controller.CombatData.Weapon.WeaponSounds.UnsheathSounds);
                    controller.Animations.SetBoolForAnimation(controller.CombatData.Weapon.AttackStanceAnimation, true);
                    controller.IsWeaponEquipped = true;
                }
            }
        }
    }
}
