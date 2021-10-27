using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AD.Animation;

namespace AD.AI
{
    public class AIMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private IAnimation _animation;
        private Rigidbody _rigidbody;

        public NavMeshAgent NavMeshAgent { get => _navMeshAgent; }

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animation = GetComponent<HumanoidAnimations>();
        }

        void Update()
        {
            SetRootMotionPosition();
            EnableNavMeshUpdatePosition();
            _animation.SetAnimationFloat("Move", _navMeshAgent.velocity.magnitude);
        }

        private void SetRootMotionPosition()
        {
            if (_animation.GetAnimationBool("IsUsingRootMotion"))
            {
                _rigidbody.isKinematic = false;
                DisableNavMeshUpdatePosition();
                Vector3 animationDelta = _animation.GetAnimationDeltaPosition();
                transform.position = this.transform.position + animationDelta * 5 * Time.deltaTime * 15;
                _navMeshAgent.nextPosition = transform.position;
            }
        }

        private void DisableNavMeshUpdatePosition()
        {
            _navMeshAgent.updatePosition = false;
            StopMovement();
            _navMeshAgent.ResetPath();
        }

        private void EnableNavMeshUpdatePosition()
        {
            if (!_animation.GetAnimationBool("IsUsingRootMotion")
                && !_navMeshAgent.updatePosition)
            {
                _rigidbody.isKinematic = true;
                _navMeshAgent.updatePosition = true;
            }
        }

        public void SetDestination(Vector3 vector)
        {
            if (_navMeshAgent.updatePosition != false)
            {
                _navMeshAgent.destination = vector;
                _navMeshAgent.isStopped = false;
            }
        }

        public void StopMovement()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}