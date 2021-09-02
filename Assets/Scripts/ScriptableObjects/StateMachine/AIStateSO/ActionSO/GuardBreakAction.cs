using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Actions/GuardBreak")]
    public class GuardBreakAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            /*
             * Check if AI is blocking
             * Check if block hit count hits max count over a short period of time
             * If above is true trigger the guard break animation
             */
        }
    }
}
