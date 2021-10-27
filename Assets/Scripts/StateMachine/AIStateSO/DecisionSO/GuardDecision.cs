using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Guard")]
    public class GuardDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            return controller.BaseStats.Stamina.IsRegenerating;
        }
    }
}