using UnityEngine;
using AD.AI;
using AD.Agent;
using AD.AI.Stats;
using AD.Interfaces;
using AD.Animation;

namespace AD.StateMachine.AI
{
    public class AIStateController : MonoBehaviour
    {
        [SerializeField] private AIState _currentState;
        [SerializeField] private AIState _remainState;
        [SerializeField] private AIStats _aIStats;
        private float _stateTimeElapsed;

        public AIStats AIStats { get => _aIStats; }
        public AIMovement Movement { get; private set; }
        public AIWayPoint WayPoint { get; private set; }
        public AICombat Combat { get; private set; }
        public IBaseStats BaseStats { get; set; }
        public HumanoidAnimations Animations { get; private set; }

        private void Awake()
        {
            Animations = GetComponent<HumanoidAnimations>();
            Movement = GetComponent<AIMovement>();
            WayPoint = GetComponent<AIWayPoint>();
            Combat = GetComponent<AICombat>();
            BaseStats = GetComponent<AgentStats>();
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void TransitionToState(AIState nextState)
        {
            if (nextState != _remainState)
            {
                _currentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            _stateTimeElapsed += Time.deltaTime;
            return (_stateTimeElapsed >= duration);
        }

        public int RandomRange()
        {
            return UnityEngine.Random.Range(0, 10);
        }

        private void OnExitState()
        {
            _stateTimeElapsed = 0;
        }
    }
}
