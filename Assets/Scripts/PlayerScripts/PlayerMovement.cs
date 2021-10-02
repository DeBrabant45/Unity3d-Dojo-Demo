using AD.Animation;
using UnityEngine;

namespace AD.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _gravity;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _angleRotationThreshold;

        private CharacterController _characterController;
        private Vector3 _moveDirection = Vector3.zero;
        private float _desiredRotationAngle = 0;
        private IAnimation _animation;
        private int _inputVerticalDirection = 0;
        private bool _temporaryMovementTriggered = false;
        private Vector2 _input;
        private Transform _mainCameraTransform;
        private bool _isMoving = false;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animation = GetComponent<HumanoidAnimations>();
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
                        StopMovement();
                    }
                }
            }
        }

        private void Update()
        {
            if (CharacterIsGrounded())
            {
                if (_isMoving)
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
                    _animation.SetAnimationFloat("InputX", _animation.SetAnimationFloatInput(_input.x, _animation.GetAnimationFloat("InputX")));
                    _animation.SetAnimationFloat("InputY", _animation.SetAnimationFloatInput(_input.y, _animation.GetAnimationFloat("InputY")));
                }
            }

            if (_animation.GetAnimationBool("IsUsingRootMotion") != false)
            {
                Vector3 animationDelta = _animation.GetAnimationDeltaPosition();
                _characterController.Move(animationDelta * _movementSpeed * Time.deltaTime * 20);
            }
            else
            {
                _moveDirection.y -= _gravity;
                _characterController.Move(_moveDirection * _movementSpeed * Time.deltaTime);
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

        public void StopMovement()
        {
            _isMoving = false;
            _moveDirection = Vector3.zero;
            _desiredRotationAngle = 0;
            _inputVerticalDirection = 0;
            _animation.SetAnimationFloat("InputX", _animation.LowerAnimationFloatInputToZero(_animation.GetAnimationFloat("InputX")));
            _animation.SetAnimationFloat("InputY", _animation.LowerAnimationFloatInputToZero(_animation.GetAnimationFloat("InputY")));
        }

        public bool CharacterIsGrounded()
        {
            return _characterController.isGrounded;
        }
    }
}