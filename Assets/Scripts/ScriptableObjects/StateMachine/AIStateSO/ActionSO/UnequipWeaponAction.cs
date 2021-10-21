using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/UnequipWeapon")]
    public class UnequipWeaponAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (!controller.Animations.IsAnimatorBusy())
            {
                UnequipWeapon(controller);
            }
        }

        private void UnequipWeapon(AIStateController controller)
        {
            if (controller.IsWeaponEquipped != false)
            {
                bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 20, controller.CombatData.TargetLayer);
                if (!isTargetInSightRange)
                {
                    controller.Animations.SetTriggerForAnimation(controller.CombatData.Weapon.SheatheAnimation);
                    controller.AudioFX.PlayOneShotAtRandomIndex(controller.CombatData.Weapon.WeaponSounds.SheathSounds);
                    controller.Animations.SetBoolForAnimation(controller.CombatData.Weapon.AttackStanceAnimation, false);
                    controller.IsWeaponEquipped = false;
                }
            }
        }
    }
}
