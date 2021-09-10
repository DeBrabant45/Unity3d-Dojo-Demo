using UnityEngine;

namespace AD.BaseStats
{
    [CreateAssetMenu(menuName = "CharacterStats/BaseStats/Health")]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] private int _initialValue;
        public int InitialValue { get => _initialValue; }
    }
}