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
        private Vector2 _input;
        private float _desiredRotationAngle = 0;
        private IAnimation _animation;
        private Transform _mainCameraTransform;
        private bool _isMovementHorizontal = false;
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
                    _isMovementHorizontal = false;
                    SetMoveDirectionToYInput(input);
                }
                else if (input.x != 0)
                {
                    _isMovementHorizontal = true;
                    SetMovementDirectionToXInput(input);
                }
                else
                {
                    StopMovement();
                }
            }
        }

        private void SetMovementDirectionToXInput(Vector2 input)
        {
            _moveDirection = new Vector3(input.x, 0f, 0f);
            _isMoving = true;
        }

        private void SetMoveDirectionToYInput(Vector2 input)
        {
            _moveDirection = input.y * transform.forward;
            _isMoving = true;
        }

        private void Update()
        {
            SetCharacterMovementDirection();
            MoveCharacter();
        }

        private void SetCharacterMovementDirection()
        {
            if (CharacterIsGrounded())
            {
                if (_isMoving)
                {
                    if (_isMovementHorizontal == false)
                    {
                        RotateCharacterBasedOnVeritcalInput();
                    }
                    else
                    {
                        SetMovementDirectionBasedOnHorizontalInput();
                    }
                    SetMovementAnimationBasedOnXYInput();
                }
            }
        }

        private void RotateCharacterBasedOnVeritcalInput()
        {
            //Rotates player based on users joystick direction
            if (_desiredRotationAngle > _angleRotationThreshold || _desiredRotationAngle < -_angleRotationThreshold)
            {
                transform.Rotate(Vector3.up * _desiredRotationAngle * _rotationSpeed * Time.deltaTime);
            }
        }

        private void SetMovementDirectionBasedOnHorizontalInput()
        {
            float targetAngle = Mathf.Atan2(_moveDirection.x, _moveDirection.z) * Mathf.Rad2Deg + _mainCameraTransform.eulerAngles.y;
            Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _moveDirection = move;
        }

        private void SetMovementAnimationBasedOnXYInput()
        {
            _animation.SetAnimationFloat("InputX", _animation.SetAnimationFloatInput(_input.x, _animation.GetAnimationFloat("InputX")));
            _animation.SetAnimationFloat("InputY", _animation.SetAnimationFloatInput(_input.y, _animation.GetAnimationFloat("InputY")));
        }

        private void MoveCharacter()
        {
            if (_animation.GetAnimationBool("IsUsingRootMotion") != false)
            {
                MoveCharacterByRootMotionPosition();
            }
            else
            {
                MoveCharacterByMoveDirectionPosition();
            }
        }

        private void MoveCharacterByMoveDirectionPosition()
        {
            _moveDirection.y -= _gravity;
            _characterController.Move(_moveDirection * _movementSpeed * Time.deltaTime);
        }

        private void MoveCharacterByRootMotionPosition()
        {
            Vector3 animationDelta = _animation.GetAnimationDeltaPosition();
            _characterController.Move(animationDelta * _movementSpeed * Time.deltaTime * 20);
        }

        public void HandleMovementDirection(Vector3 input)
        {
            if (_isMovementHorizontal)
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

        private void StopMovement()
        {
            _isMoving = false;
            _moveDirection = Vector3.zero;
            _desiredRotationAngle = 0;
            _animation.SetAnimationFloat("InputX", _animation.LowerAnimationFloatInputToZero(_animation.GetAnimationFloat("InputX")));
            _animation.SetAnimationFloat("InputY", _animation.LowerAnimationFloatInputToZero(_animation.GetAnimationFloat("InputY")));
        }

        public bool CharacterIsGrounded()
        {
            return _characterController.isGrounded;
        }
    }
}