using UnityEngine;

namespace AD.Animation
{
    public class AnimatorService : IAnimatorService
    {
        private Animator _animator;

        public AnimatorService(Animator animator)
        {
            _animator = animator;
        }

        public void SetTriggerForAnimation(string name)
        {
            _animator.SetTrigger(name);
        }

        public void ResetTriggerForAnimation(string name)
        {
            _animator.ResetTrigger(name);
        }

        public void SetBoolForAnimation(string name, bool value)
        {
            _animator.SetBool(name, value);
        }

        public bool GetAnimationBool(string name)
        {
            return _animator.GetBool(name);
        }

        public void SetAnimationFloat(string id, float value)
        {
            _animator.SetFloat(id, value);
        }

        public float GetAnimationFloat(string id)
        {
            return _animator.GetFloat(id);
        }

        public float SetAnimationFloatInput(float inputDirection, float animationDirection)
        {
            float current = animationDirection;
            current += inputDirection * Time.deltaTime * 2;
            current = Mathf.Clamp(current, -1, 1);
            return current;
        }

        public float LowerAnimationFloatInputToZero(float animationDirection)
        {
            float current = animationDirection;
            if (current > 0)
            {
                current -= 1f * Time.deltaTime * 3;
                current = Mathf.Clamp(current, 0, 1);
            }
            else if (current < 0)
            {
                current -= -1f * Time.deltaTime * 3;
                current = Mathf.Clamp(current, -1, 0);
            }
            return current;
        }

        public Vector3 GetAnimationDeltaPosition()
        {
            Vector3 deltaPosition = _animator.deltaPosition;
            deltaPosition.y = 0;
            return deltaPosition;
        }
    }
}
