using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.AI.Stats
{
    [CreateAssetMenu(menuName = "Stats/AIStats")]
    public class AIStats : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private float _sightRange;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _searchingTurnSpeed;
        [SerializeField] private float _searchDuration;

        public string Id { get => _id; }
        public float SightRange { get => _sightRange; }
        public float AttackRange { get => _attackRange; }
        public float SearchingTurnSpeed { get => _searchingTurnSpeed; }
        public float SearchDuration { get => _searchDuration; }
        public float AttackRate { get => _attackRate; }
    }
}