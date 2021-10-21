using UnityEngine;

namespace AD.BaseStats
{
    [CreateAssetMenu(menuName = "CharacterStats/BaseStats/Stamina")]
    public class StaminaSO : ScriptableObject
    {
        [SerializeField] private int _initialValue;
        [SerializeField] private float _regenSpeed;
        [SerializeField] private float _regenAmount;

        public int InitialValue { get => _initialValue; }
        public float RegenSpeed { get => _regenSpeed; }
        public float RegenAmount { get => _regenAmount; }
    }
}
