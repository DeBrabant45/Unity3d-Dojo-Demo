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
        private IUnityInputService _unityInputService;

        public Vector2 MovementInputVector { get; private set; }
        public Vector3 MovementDirectionVector { get; private set; }

        public void Constructor(IUnityInputService unityInputService)
        {
            _unityInputService = unityInputService;
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
            Cursor.lockState = CursorLockMode.Locked;
            if (_unityInputService == null)
            {
                Constructor(new UnityInputService());
            }
        }

        private void Update()
        {
            GetMovementInput();
            GetMovementDirection();
        }

        public bool IsSecondaryUpAction()
        {
            return _unityInputService.GetMouseButtonUp(1);
        }

        public bool IsSecondaryHeldDownAction()
        {
            return _unityInputService.GetMouseuButtonPressedDown(1);
        }

        public bool IsEscapeKeyPressed()
        {
            return _unityInputService.GetKeyButtonPressedDown(KeyCode.Escape);
        }

        public bool IsSecondaryActionPressed()
        {
            var inputValue = _unityInputService.GetAxisRaw("Fire2");
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

        public bool IsPrimaryActionPressed()
        {
            var inputValue = _unityInputService.GetAxisRaw("Fire1");
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
            return _unityInputService.GetKeyButtonPressedDown(KeyCode.LeftShift);
        }

        public bool IsRKeyPressed()
        {
            return _unityInputService.GetKeyButtonPressedDown(KeyCode.R);
        }

        public bool IsSpacebarPressed()
        {
            return _unityInputService.GetKeyButtonPressedDown(KeyCode.Space);
        }

        private void GetMovementDirection()
        {
            var cameraForwardDirection = _mainCamera.transform.forward;
            MovementDirectionVector = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        }

        private void GetMovementInput()
        {
            MovementInputVector = new Vector2(_unityInputService.GetAxisRaw("Horizontal"), _unityInputService.GetAxisRaw("Vertical"));
        }
    }
}