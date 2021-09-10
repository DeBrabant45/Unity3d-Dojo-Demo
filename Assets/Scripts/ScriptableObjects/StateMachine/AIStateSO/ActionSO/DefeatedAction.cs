using System;
using UnityEngine;

namespace AD.StateMachine.AI
{
    public class DefeatedAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            /**
             * Check if Health as hit zero then do the defeated action
             * Defeated(controller);
             */

        }

        private void Defeated(AIStateController controller)
        {
            throw new NotImplementedException();
        }
    }
}
