﻿using System;
using UnityEngine;

namespace AD.Animation
{
    public class HumanoidAnimations : MonoBehaviour
    {
        private Animator _animator;
        private Action _animationFunctionTrigger;
        private int _inputX;
        private int _inputY;

        public Action OnAnimationFunctionTrigger { get => _animationFunctionTrigger; set => _animationFunctionTrigger = value; }
        public int InputX { get => _inputX; }
        public int InputY { get => _inputY; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputX = Animator.StringToHash("InputX");
            _inputY = Animator.StringToHash("InputY");
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

        public void AnimationFunctionTriggerCallBack()
        {
            _animationFunctionTrigger.Invoke();
        }

        public void SetAnimationFloat(int id, float value)
        {
            _animator.SetFloat(id, value);
        }

        public float GetAnimationFloat(int id)
        {
            return _animator.GetFloat(id);
        }

        public bool IsInteracting()
        {
            return _animator.GetBool("IsInteracting");
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

        private void OnAnimatorMove()
        {
            if (GetAnimationBool("IsUsingRootMotion") != false)
            {
                GetAnimationDeltaPosition();
            }
        }

        public Vector3 GetAnimationDeltaPosition()
        {
            Vector3 deltaPosition = _animator.deltaPosition;
            deltaPosition.y = 0;
            return deltaPosition;
        }
    }
}