using System;
using AD.Interfaces;
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
        public ITagable AttackerTag { get; set; }
        public bool IsBlocking { get => _isBlocking; set => _isBlocking = value; }

        public bool IsBlockHitSuccessful()
        {
            if (_isBlocking != false)
            {
                RaycastHit hit;
                if (Physics.SphereCast(_blockRaycastStartPosition.position, 0.2f, transform.forward, out hit, _blockDistance))
                {
                    if (AttackerTag != null && hit.collider.gameObject.tag == AttackerTag.TagName)
                    {
                        return true;
                    }
                }
            }
            else if (AttackerTag != null)
            {
                AttackerTag = null;
            }
            return false;
        }
    }
}