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
        private HumanoidAnimations _animation;

        public NavMeshAgent NavMeshAgent { get => _navMeshAgent; }

        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animation = GetComponent<HumanoidAnimations>();
        }

        void Update()
        {
            SetRootMotionPosition();
            EnableNavMeshUpdatePosition();
            _animation.AnimatorService.SetAnimationFloat("Move", _navMeshAgent.velocity.magnitude);
        }

        private void SetRootMotionPosition()
        {
            if (_animation.AnimatorService.GetAnimationBool("IsUsingRootMotion"))
            {
                _navMeshAgent.updatePosition = false;
                Vector3 animationDelta = _animation.AnimatorService.GetAnimationDeltaPosition();
                transform.position = this.transform.position + animationDelta * 5 * Time.deltaTime * 15;
                _navMeshAgent.nextPosition = transform.position;
            }
        }

        private void EnableNavMeshUpdatePosition()
        {
            if (!_animation.AnimatorService.GetAnimationBool("IsUsingRootMotion")
                && !_navMeshAgent.updatePosition)
            {
                _navMeshAgent.updatePosition = true;
            }
        }

        public void SetDestination(Vector3 vector)
        {
            _navMeshAgent.destination = vector;
            _navMeshAgent.isStopped = false;
        }

        public void StopMovement()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}