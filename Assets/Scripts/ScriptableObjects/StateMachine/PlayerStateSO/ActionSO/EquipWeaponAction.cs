using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Action/EquipWeapon")]
    public class EquipWeaponAction : PlayerAction
    {
        public override void Act(PlayerStateController controller)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                controller.AgentAnimations.SetBoolForAnimation("meleeWeaponStance", true);
            }
        }
    }
}
