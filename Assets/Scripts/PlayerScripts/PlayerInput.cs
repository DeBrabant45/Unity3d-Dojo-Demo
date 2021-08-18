using System;
using UnityEngine;
using AD.Interfaces;

namespace AD.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Camera _mainCamera;
        private float _previousPrimaryActionInput = 0;
        private float _previousSecondaryActionInput = 0;
        private IPlayerInputService _playerInputService;

        public Vector2 MovementInputVector { get; private set; }
        public Vector3 MovementDirectionVector { get; private set; }
        public IPlayerInputService PlayerInputService { get => _playerInputService; set => _playerInputService = value; }

        private void Awake()
        {
            _mainCamera = Camera.main;
            Cursor.lockState = CursorLockMode.Locked;
            if (_playerInputService == null)
            {
                _playerInputService = new PlayerInputService();
            }
        }

        private void Update()
        {
            GetMovementInput();
            GetMovementDirection();
        }

        public bool IsSecondaryUpAction()
        {
            return _playerInputService.GetMouseButtonUp(1);
        }

        public bool IsSecondaryHeldDownAction()
        {
            return _playerInputService.GetMouseuButtonPressedDown(1);
        }

        public bool IsEscapeKeyPressed()
        {
            return _playerInputService.GetKeyButtonPressedDown(KeyCode.Escape);
        }

        public bool IsSecondaryClickAction()
        {
            var inputValue = _playerInputService.GetAxisRaw("Fire2");
            if (_previousSecondaryActionInput == 0)
            {
                if (inputValue >= 1)
                {
                    return true;
                }
            }
            _previousSecondaryActionInput = inputValue;
            return false;
        }

        public bool IsPrimaryAction()
        {
            var inputValue = _playerInputService.GetAxisRaw("Fire1");
            if (_previousPrimaryActionInput == 0)
            {
                if (inputValue >= 1)
                {
                    return true;
                }
            }
            _previousPrimaryActionInput = inputValue;
            return false;
        }

        public bool IsShiftKeyPressed()
        {
            return _playerInputService.GetKeyButtonPressedDown(KeyCode.LeftShift);
        }

        public bool IsRKeyPressed()
        {
            return _playerInputService.GetKeyButtonPressedDown(KeyCode.R);
        }

        public bool IsSpacebarPressed()
        {
            return _playerInputService.GetKeyButtonPressedDown(KeyCode.Space);
        }

        private void GetMovementDirection()
        {
            var cameraForwardDirection = _mainCamera.transform.forward;
            MovementDirectionVector = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        }

        private void GetMovementInput()
        {
            MovementInputVector = new Vector2(_playerInputService.GetAxisRaw("Horizontal"), _playerInputService.GetAxisRaw("Vertical"));
        }
    }
}