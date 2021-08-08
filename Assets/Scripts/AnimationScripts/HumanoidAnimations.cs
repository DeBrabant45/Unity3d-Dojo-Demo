using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Animation
{
    public class HumanoidAnimations : MonoBehaviour
    {
        private Animator _animator;
        private Action _animationFunctionTrigger;
        private Action _onAnimationStartTrigger;
        private Action _onAnimationEndTrigger;

        public Action OnAnimationFunctionTrigger { get => _animationFunctionTrigger; set => _animationFunctionTrigger = value; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
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

        public void AnimationFunctionTriggerCallBack()
        {
            _animationFunctionTrigger.Invoke();
        }

        public void SetAnimationInputX(float value)
        {
            _animator.SetFloat("InputX", value);
        }

        public void SetAnimationInputY(float value)
        {
            _animator.SetFloat("InputY", value);
        }

        public bool IsInteracting()
        {
            return _animator.GetBool("IsInteracting");
        }
    }
}