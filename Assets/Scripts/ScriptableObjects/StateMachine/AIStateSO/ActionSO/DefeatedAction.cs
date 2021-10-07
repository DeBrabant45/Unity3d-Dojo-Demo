using AD.General;
using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/Defeated")]
    public class DefeatedAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.BaseStats.Health.Amount <= 0 && controller.enabled != false)
            {
                Defeated(controller);
            }
        }

        private void Defeated(AIStateController controller)
        {
            controller.Animations.SetBoolForAnimation("IsDefeated", true);
            controller.GetComponent<CapsuleCollider>().enabled = false;
            controller.enabled = false;
            ObjectiveEvent.Instance.DefeatedEnemy();
        }
    }
}