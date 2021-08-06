using AD.Agent;
using AD.Animation;
using System;
using UnityEngine;
using UnityEngine.Events;

public class AgentController : MonoBehaviour
{
    //[SerializeField] private GameManager _gameManager;
    [SerializeField] private Transform _itemSlotTransform;
    [SerializeField] private Transform _backItemSlotTransform;
    [SerializeField] private UnityEvent _onDeath;

    //private WeaponItemSO _equippedItem;
    private AgentMovement _movement;
    private AgentAimController _agentAimController;
    private PlayerInput _inputFromPlayer;
    private HumanoidAnimations _agentAnimations;
    //private ItemSlot _itemSlot;
    private AgentHealth _agentHealth;
    private AgentStamina _agentStamina;

    #region Class Getters
    public PlayerInput InputFromPlayer { get => _inputFromPlayer; }
    public AgentMovement Movement { get => _movement; }
    public HumanoidAnimations AgentAnimations { get => _agentAnimations; }
    public Transform ItemSlotTransform { get => _itemSlotTransform; }
    public AgentAimController AgentAimController { get => _agentAimController; }
    public Transform BackItemSlotTransform { get => _backItemSlotTransform; }
    public AgentHealth AgentHealth { get => _agentHealth; }
    public AgentStamina AgentStamina { get => _agentStamina; }
    #endregion

    private void Awake()
    {
        _movement = GetComponent<AgentMovement>();
        _inputFromPlayer = GetComponent<PlayerInput>();
        _agentAnimations = GetComponent<HumanoidAnimations>();

        _agentAimController = GetComponent<AgentAimController>();
        //_itemSlot = GetComponent<ItemSlot>();

        _agentHealth = GetComponent<AgentHealth>();
        _agentStamina = GetComponent<AgentStamina>();
    }

    private void OnEnable()
    {
        _agentHealth.OnHealthAmountEmpty += Death;
    }

    private void HandleEquippedItem()
    {
        //if (_inventorySystem.WeaponEquipped == false)
        //{
        //    _equippedItem = _unarmedAttack;
        //}
        //else
        //{
        //    _equippedItem = (WeaponItemSO)ItemDataManager.Instance.GetItemData(_inventorySystem.EquippedWeaponID);
        //}
    }


    private void Death()
    {
        _onDeath.Invoke();
    }
}