using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Decisions/EquipWeapon")]
    public class AttackStanceDecision : PlayerDecision
    {
        public override bool Decide(PlayerStateController controller)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                return true;
            }
            return false;
        }
    }
}