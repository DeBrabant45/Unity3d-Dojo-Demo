using UnityEngine;

namespace AD.BaseStats
{
    [CreateAssetMenu(menuName = "CharacterStats/BaseStats/Posture")]
    public class PostureSO : ScriptableObject
    {
        [SerializeField] private float _maxAmount;
        [SerializeField] private float _regenAmount;

        public float MaxAmount { get => _maxAmount; }
        public float RegenAmount { get => _regenAmount; }
    }
}
