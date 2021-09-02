using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/GuardReaction")]
    public class GuardReactionAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            if (controller.Combat.BlockAttack.IsBlockHitSuccessful())
            {
                GuardReaction(controller);
            }
        }

        private void GuardReaction(AIStateController controller)
        {
            /* Increase a value for how many successful blocked hits
             * Track if the deltaTime has surpassed a certain time limit if so reset the successful blocked hits value
             * Call to animator for block reaction
             */
        }
    }
}
