using UnityEngine;
using AD.AI;
using AD.Agent;
using AD.Sound;
using AD.AI.Data;
using AD.Interfaces;
using AD.Animation;

namespace AD.StateMachine.AI
{
    public class AIStateController : MonoBehaviour, ITagable
    {
        [SerializeField] private AIState _currentState;
        [SerializeField] private AIState _remainState;
        [SerializeField] private AIMovementData _movementData;
        [SerializeField] private AICombatData _combatData;
        [SerializeField] private CharacterVoice _characterVoices;
        [SerializeField] private Transform _chaseTarget;
        [SerializeField] private int _randomRangeValue;
        private float _stateTimeElapsed;

        public AIMovementData MovementData { get => _movementData; }
        public AICombatData CombatData { get => _combatData; }
        public CharacterVoice CharacterVoice { get => _characterVoices; }
        public AIMovement Movement { get; private set; }
        public AIWayPoint WayPoint { get; private set; }
        public IBaseStats BaseStats { get; set; }
        public IAnimation Animations { get; private set; }
        public BlockAttack BlockAttack { get; private set; }
        public ItemSlot ItemSlot { get; private set; }
        public AudioFX AudioFX { get; private set; }
        public float TimeBuffer { get; set; }
        public string TagName { get => this.tag; }
        public bool IsWeaponEquipped { get; set; }
        public Transform ChaseTarget { get => _chaseTarget; }

        private void Awake()
        {
            Animations = GetComponent<HumanoidAnimations>();
            Movement = GetComponent<AIMovement>();
            WayPoint = GetComponent<AIWayPoint>();
            BaseStats = GetComponent<AgentStats>();
            AudioFX = GetComponent<AudioFX>();
            BlockAttack = GetComponent<BlockAttack>();
            ItemSlot = GetComponent<ItemSlot>();
            IsWeaponEquipped = false;
        }

        private void Update()
        {
            if (Time.timeScale == 1)
            {
                _currentState.UpdateState(this);
            }
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