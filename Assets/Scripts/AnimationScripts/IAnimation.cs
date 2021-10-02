using UnityEngine;

namespace AD.Animation
{
    public interface IAnimation
    {
        public void SetTriggerForAnimation(string name);
        public void ResetTriggerForAnimation(string name);
        public void SetBoolForAnimation(string name, bool value);
        public bool GetAnimationBool(string name);
        public void SetAnimationFloat(string id, float value);
        public float GetAnimationFloat(string id);
        public float SetAnimationFloatInput(float inputDirection, float animationDirection);
        public float LowerAnimationFloatInputToZero(float animationDirection);
        public Vector3 GetAnimationDeltaPosition();
        public bool IsAnimatorBusy();
    }
}