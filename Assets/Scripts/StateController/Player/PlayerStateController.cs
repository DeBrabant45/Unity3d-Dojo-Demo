using AD.Agent;
using AD.Animation;
using AD.Interfaces;
using AD.Player;
using AD.Sound;
using AD.Weapons;
using UnityEngine;

namespace AD.StateMachine.Player
{
    public class PlayerStateController : MonoBehaviour, ITagable
    {
        [SerializeField] private PlayerState _currentState;
        [SerializeField] private PlayerState _remainState;
        [SerializeField] private WeaponSO _weapon;
        [SerializeField] private CharacterVoice _characterVoice;
        [SerializeField] private GameObject _bodyCollider;

        public IBaseStats BaseStats { get; private set; }
        public IAnimation Animations { get; private set; }
        public string TagName { get => this.tag; }
        public PlayerInput InputFromPlayer { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public PlayerAimController AgentAimController { get; private set; }
        public ItemSlot ItemSlot { get; private set; }
        public WeaponSO Weapon { get => _weapon; }
        public BlockAttack BlockAttack { get; private set; }
        public PlayerState CurrentState { get => _currentState; }
        public AudioFX AudioFX { get; private set; }
        public CharacterVoice CharacterVoice { get => _characterVoice; set => _characterVoice = value; }
        public GameObject BodyCollider { get => _bodyCollider; }

        private void Awake()
        {
            Movement = GetComponent<PlayerMovement>();
            InputFromPlayer = GetComponent<PlayerInput>();
            Animations = GetComponent<HumanoidAnimations>();
            ItemSlot = GetComponent<ItemSlot>();
            AgentAimController = GetComponent<PlayerAimController>();
            BlockAttack = GetComponent<BlockAttack>();
            BaseStats = GetComponent<AgentStats>();
            AudioFX = GetComponent<AudioFX>();
        }

        private void Update()
        {
            if (Time.timeScale == 1)
            {
                _currentState.UpdateState(this);
            }
        }

        public void Constructor(PlayerState currentState, PlayerState remainState, PlayerInput input)
        {
            _currentState = currentState;
            _remainState = remainState;
            InputFromPlayer = input;
        }

        public void TransitionToState(PlayerState nextState)
        {
            if (nextState != _remainState)
            {
                _currentState = nextState;
            }
        }
    }
}
