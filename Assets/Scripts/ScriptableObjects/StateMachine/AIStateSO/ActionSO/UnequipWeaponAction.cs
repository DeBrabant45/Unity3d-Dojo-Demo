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
            UnequipWeapon(controller);
        }

        private void UnequipWeapon(AIStateController controller)
        {
            if (controller.IsWeaponEquipped != false)
            {
                bool isTargetInSightRange = Physics.CheckSphere(controller.transform.position, 5, controller.Layer);
                if (!isTargetInSightRange)
                {
                    Debug.Log("Unequip Item");
                    controller.IsWeaponEquipped = false;
                }
            }
        }
    }
}
