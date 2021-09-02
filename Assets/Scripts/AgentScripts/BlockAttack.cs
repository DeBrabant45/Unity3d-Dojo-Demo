using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Agent
{
    public class BlockAttack : MonoBehaviour, IBlockable
    {
        [SerializeField] Transform _blockRaycastStartPosition;
        [SerializeField] private float _blockDistance = 0.8f;
        private bool _isBlocking = false;

        public int BlockLevel => throw new NotImplementedException();
        public Action OnBlockSuccessful { get; set; }
        public GameObject Attacker { get; set; }
        public bool IsBlocking { get => _isBlocking; set => _isBlocking = value; }

        public bool IsBlockHitSuccessful()
        {
            if (_isBlocking != false)
            {
                RaycastHit hit;
                if (Physics.SphereCast(_blockRaycastStartPosition.position, 0.2f, transform.forward, out hit, _blockDistance))
                {
                    if (hit.collider.gameObject == Attacker)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}