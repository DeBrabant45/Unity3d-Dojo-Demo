using UnityEngine;

namespace AD.AI.Data
{
    [CreateAssetMenu(menuName = "AI/Data/Movement")]
    public class AIMovementData : ScriptableObject
    {
        [SerializeField] private float _sightRange;
        [SerializeField] private float _searchingTurnSpeed;
        [SerializeField] private float _searchDuration;
        [SerializeField] private int _rollNumber;

        public float SightRange { get => _sightRange; }
        public float SearchingTurnSpeed { get => _searchingTurnSpeed; }
        public float SearchDuration { get => _searchDuration; }
        public float RollNumber { get => _rollNumber; }
    }
}