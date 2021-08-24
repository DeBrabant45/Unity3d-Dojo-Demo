using AD.Animation;
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

        private CharacterController _characterController;
        private Vector3 _moveDirection = Vector3.zero;
        private float _desiredRotationAngle = 0;
        private HumanoidAnimations _agentAnimations;
        private int _inputVerticalDirection = 0;
        private bool _isJumping = false;
        private bool _isJumpingCompleted = true;
        private bool _temporaryMovementTriggered = false;
        private Vector2 _input;
        private Transform _mainCameraTransform;
        private bool _isMoving = false;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _agentAnimations = GetComponent<HumanoidAnimations>();
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
                    _moveDirection = input.y * transform.forward;
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
                        _moveDirection = new Vector3(input.x, 0f, 0f);
                        _isMoving = true;
                    }
                    else
                    {
                        _temporaryMovementTriggered = false;
                        _agentAnimations.SetAnimationFloat(_agentAnimations.InputX, _agentAnimations.LowerAnimationFloatInputToZero(_agentAnimations.GetAnimationFloat(_agentAnimations.InputX)));
                        _agentAnimations.SetAnimationFloat(_agentAnimations.InputY, _agentAnimations.LowerAnimationFloatInputToZero(_agentAnimations.GetAnimationFloat(_agentAnimations.InputY)));
                        _moveDirection = Vector3.zero;
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
                        float targetAngle = Mathf.Atan2(_moveDirection.x, _moveDirection.z) * Mathf.Rad2Deg + _mainCameraTransform.eulerAngles.y;
                        Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                        _moveDirection = move;
                    }
                    _agentAnimations.SetAnimationFloat(_agentAnimations.InputX, _agentAnimations.SetAnimationFloatInput(_input.x, _agentAnimations.GetAnimationFloat(_agentAnimations.InputX)));
                    _agentAnimations.SetAnimationFloat(_agentAnimations.InputY, _agentAnimations.SetAnimationFloatInput(_input.y, _agentAnimations.GetAnimationFloat(_agentAnimations.InputY)));
                }
            }

            if (_agentAnimations.GetAnimationBool("IsUsingRootMotion") != false)
            {
                Vector3 animationDelta = _agentAnimations.GetAnimationDeltaPosition();
                _characterController.Move(animationDelta * _movementSpeed * Time.deltaTime * 35);
            }
            else
            {
                _moveDirection.y -= _gravity;
                AgentIsJumping();
                _characterController.Move(_moveDirection * _movementSpeed * Time.deltaTime);
            }
        }

        private void AgentIsJumping()
        {
            if (_isJumping == true)
            {
                _isMoving = false;
                _isJumping = false;
                _isJumpingCompleted = false;
                _moveDirection.y = _jumpSpeed;
                _agentAnimations.SetTriggerForAnimation("jump");
            }
        }

        private void RotateAgent()
        {
            //Rotates player based on users joystick direction
            if (_desiredRotationAngle > _angleRotationThreshold || _desiredRotationAngle < -_angleRotationThreshold)
            {
                transform.Rotate(Vector3.up * _desiredRotationAngle * _rotationSpeed * Time.deltaTime);
            }
        }

        public void HandleMovementDirection(Vector3 input)
        {
            if (_temporaryMovementTriggered)
            {
                return;
            }
            _desiredRotationAngle = Vector3.Angle(transform.forward, input);
            var crossProduct = Vector3.Cross(transform.forward, input).y;
            if (crossProduct < 0)
            {
                _desiredRotationAngle *= -1;
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
            _moveDirection = Vector3.zero;
            _desiredRotationAngle = 0;
            _inputVerticalDirection = 0;
            _agentAnimations.SetAnimationFloat(_agentAnimations.InputX, _agentAnimations.LowerAnimationFloatInputToZero(_agentAnimations.GetAnimationFloat(_agentAnimations.InputX)));
            _agentAnimations.SetAnimationFloat(_agentAnimations.InputY, _agentAnimations.LowerAnimationFloatInputToZero(_agentAnimations.GetAnimationFloat(_agentAnimations.InputY)));
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
            return _characterController.isGrounded;
        }

        public void TeleportPlayerTo(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position;
            _characterController.enabled = true;
        }
    }
}
