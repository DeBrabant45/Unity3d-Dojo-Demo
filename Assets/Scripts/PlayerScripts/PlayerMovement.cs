﻿using AD.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _gravity;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private int _angleRotationThreshold;

        private CharacterController characterController;
        private Vector3 moveDirection = Vector3.zero;
        private float desiredRotationAngle = 0;
        private HumanoidAnimations agentAnimations;
        private int _inputVerticalDirection = 0;
        private bool _isJumping = false;
        private bool _isJumpingCompleted = true;
        private bool _temporaryMovementTriggered = false;
        private Vector2 _input;
        private Transform _mainCameraTransform;
        private bool _isMoving = false;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            agentAnimations = GetComponent<HumanoidAnimations>();
            _mainCameraTransform = Camera.main.transform;
        }

        public void HandleMovement(Vector2 input)
        {
            _input = input;
            if (CharacterIsGrounded())
            {
                if (input.y != 0)
                {
                    _temporaryMovementTriggered = false;
                    if (input.y > 0)
                    {
                        //while player is moving forward
                        _inputVerticalDirection = Mathf.CeilToInt(input.y);
                    }
                    else
                    {
                        //while player is moving backward
                        _inputVerticalDirection = Mathf.FloorToInt(input.y);
                    }
                    moveDirection = input.y * transform.forward;
                    _isMoving = true;
                }
                else
                {
                    if (input.x != 0)
                    {
                        if (_temporaryMovementTriggered == false)
                        {
                            _temporaryMovementTriggered = true;
                        }
                        _inputVerticalDirection = 1;
                        moveDirection = new Vector3(input.x, 0f, 0f);
                        _isMoving = true;
                    }
                    else
                    {
                        _temporaryMovementTriggered = false;
                        agentAnimations.SetAnimationFloat(agentAnimations.InputX, agentAnimations.LowerAnimationFloatInputToZero(agentAnimations.GetAnimationFloat(agentAnimations.InputX)));
                        agentAnimations.SetAnimationFloat(agentAnimations.InputY, agentAnimations.LowerAnimationFloatInputToZero(agentAnimations.GetAnimationFloat(agentAnimations.InputY)));
                        moveDirection = Vector3.zero;
                    }
                }
            }
        }

        private void Update()
        {
            if (CharacterIsGrounded())
            {
                if (_isMoving && _isJumpingCompleted)
                {
                    if (_temporaryMovementTriggered == false)
                    {
                        RotateAgent();
                    }
                    else
                    {
                        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + _mainCameraTransform.eulerAngles.y;
                        Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                        moveDirection = move;
                    }
                    agentAnimations.SetAnimationFloat(agentAnimations.InputX, agentAnimations.SetAnimationFloatInput(_input.x, agentAnimations.GetAnimationFloat(agentAnimations.InputX)));
                    agentAnimations.SetAnimationFloat(agentAnimations.InputY, agentAnimations.SetAnimationFloatInput(_input.y, agentAnimations.GetAnimationFloat(agentAnimations.InputY)));
                }
            }

            if (agentAnimations.GetAnimationBool("IsUsingRootMotion") != false)
            {
                Vector3 animationDelta = agentAnimations.GetAnimationDeltaPosition();
                characterController.Move(animationDelta * _movementSpeed * Time.deltaTime * 35);
            }
            else
            {
                moveDirection.y -= _gravity;
                AgentIsJumping();
                characterController.Move(moveDirection * _movementSpeed * Time.deltaTime);
            }
        }

        private void AgentIsJumping()
        {
            if (_isJumping == true)
            {
                _isMoving = false;
                _isJumping = false;
                _isJumpingCompleted = false;
                moveDirection.y = _jumpSpeed;
                agentAnimations.SetTriggerForAnimation("jump");
            }
        }

        private void RotateAgent()
        {
            //Rotates player based on users joystick direction
            if (desiredRotationAngle > _angleRotationThreshold || desiredRotationAngle < -_angleRotationThreshold)
            {
                transform.Rotate(Vector3.up * desiredRotationAngle * _rotationSpeed * Time.deltaTime);
            }
        }

        public void HandleMovementDirection(Vector3 input)
        {
            if (_temporaryMovementTriggered)
            {
                return;
            }
            desiredRotationAngle = Vector3.Angle(transform.forward, input);
            var crossProduct = Vector3.Cross(transform.forward, input).y;
            if (crossProduct < 0)
            {
                desiredRotationAngle *= -1;
            }
        }

        public void HandleJump()
        {
            if (CharacterIsGrounded())
            {
                _isJumping = true;
            }
        }

        public void StopMovement()
        {
            _isMoving = false;
            moveDirection = Vector3.zero;
            desiredRotationAngle = 0;
            _inputVerticalDirection = 0;
            agentAnimations.SetAnimationFloat(agentAnimations.InputX, agentAnimations.LowerAnimationFloatInputToZero(agentAnimations.GetAnimationFloat(agentAnimations.InputX)));
            agentAnimations.SetAnimationFloat(agentAnimations.InputY, agentAnimations.LowerAnimationFloatInputToZero(agentAnimations.GetAnimationFloat(agentAnimations.InputY)));
        }

        public bool HasCompletedJumping()
        {
            return _isJumpingCompleted;
        }

        public void SetCompletedJumping(bool value)
        {
            _isJumpingCompleted = value;
        }

        public void SetCompletedJumpTrue()
        {
            _isJumpingCompleted = true;
        }

        public void SetCompletedJumpFalse()
        {
            _isJumpingCompleted = false;
        }

        public bool CharacterIsGrounded()
        {
            return characterController.isGrounded;
        }

        public void TeleportPlayerTo(Vector3 position)
        {
            characterController.enabled = false;
            transform.position = position;
            characterController.enabled = true;
        }
    }
}