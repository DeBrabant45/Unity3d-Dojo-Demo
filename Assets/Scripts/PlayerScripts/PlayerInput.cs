using System;
using UnityEngine;
using AD.Interfaces;

namespace AD.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Camera _mainCamera;
        private IUnityInputService _unityInputService;

        public Vector2 MovementInputVector { get; private set; }
        public Vector3 MovementDirectionVector { get; private set; }
        public IUnityInputService UnityInputService { get => _unityInputService; set => _unityInputService = value; }

        private void Awake()
        {
            _mainCamera = Camera.main;
            Cursor.lockState = CursorLockMode.Locked;
            if (_unityInputService == null)
            {
                _unityInputService = new UnityInputService();
            }
        }

        private void Update()
        {
            GetMovementInput();
            GetMovementDirection();
        }

        public bool IsSecondaryHeldDownAction()
        {
            return _unityInputService.GetMouseButton(1);
        }

        public bool IsEscapeKeyPressed()
        {
            return _unityInputService.GetKeyButtonPressedDown(KeyCode.Escape);
        }

        public bool IsSecondaryActionPressed()
        {
            return _unityInputService.GetAxisRawPressedDown("Fire2"); 
        }

        public bool IsPrimaryActionPressed()
        {
            return _unityInputService.GetAxisRawPressedDown("Fire1");
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