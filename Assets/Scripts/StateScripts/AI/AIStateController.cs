using UnityEngine;
using AD.AI;
using AD.Agent;
using AD.Sound;
using AD.AI.Stats;
using AD.Interfaces;
using AD.Animation;

namespace AD.StateMachine.AI
{
    public class AIStateController : MonoBehaviour, ITagable
    {
        [SerializeField] private AIState _currentState;
        [SerializeField] private AIState _remainState;
        [SerializeField] private AIStats _aIStats;
        [SerializeField] private CharacterVoice _characterVoices;
        [SerializeField] private int _randomRangeValue;
        private float _stateTimeElapsed;

        public AIStats AIStats { get => _aIStats; }
        public AIMovement Movement { get; private set; }
        public AIWayPoint WayPoint { get; private set; }
        public AICombat Combat { get; private set; }
        public IBaseStats BaseStats { get; set; }
        public IAnimation Animations { get; private set; }
        public string TagName { get => this.tag; }
        public AudioFX AudioFX { get; private set; }
        public CharacterVoice CharacterVoice { get => _characterVoices; set => _characterVoices = value; }

        private void Awake()
        {
            Animations = GetComponent<HumanoidAnimations>();
            Movement = GetComponent<AIMovement>();
            WayPoint = GetComponent<AIWayPoint>();
            BaseStats = GetComponent<AgentStats>();
            Combat = GetComponent<AICombat>();
            AudioFX = GetComponent<AudioFX>();
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
            return UnityEngine.Random.Range(0, _randomRangeValue);
        }

        private void OnExitState()
        {
            _stateTimeElapsed = 0;
        }
    }
}