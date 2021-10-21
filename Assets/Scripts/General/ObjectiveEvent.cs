using System;
using System.Collections;
using UnityEngine;

namespace AD.General
{
    public class ObjectiveEvent : MonoBehaviour
    {
        public static ObjectiveEvent Instance;
        public Action OnEnemyDefeated { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void DefeatedEnemy()
        {
            OnEnemyDefeated?.Invoke();
        }
    }
}