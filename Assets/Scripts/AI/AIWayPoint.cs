using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.AI
{
    public class AIWayPoint : MonoBehaviour
    {
        [SerializeField] private List<Transform> _wayPoints;
        public int NextWayPoint { get; set; }
        public List<Transform> WayPoints { get => _wayPoints; }
    }
}