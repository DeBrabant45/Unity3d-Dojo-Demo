﻿using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Animations.Rigging;
using System;

namespace AD.Player
{
    public class PlayerAimController : MonoBehaviour
    {
        [SerializeField] private float _turnSpeed = 5f;
        [SerializeField] private float _aimDuration = 0.3f;
        [SerializeField] private Image _aimCrossHair;
        [SerializeField] private CinemachineFreeLook _playerFollowCamera;
        [SerializeField] private int _cameraZoomInFieldOfView;
        [SerializeField] private int _cameraZoomOutFieldOfView;
        [SerializeField] private Rig _playerAim;
        [SerializeField] private MultiAimConstraint _leftHand;
        [SerializeField] private MultiAimConstraint _rightHand;
        private bool _isAimActive = false;
        private bool _isHandsConstraintActive = false;
        private Camera _mainCamera;

        public Image AimCrossHair { get => _aimCrossHair; set => _aimCrossHair = value; }
        public bool IsAimActive { get => _isAimActive; set => _isAimActive = value; }
        public bool IsHandsConstraintActive { get => _isHandsConstraintActive; set => _isHandsConstraintActive = value; }

        private void Start()
        {
            _mainCamera = Camera.main;
            //_aimCrossHair.enabled = false;
            ////_playerAim.weight = 0;
            //_leftHand.weight = 0;
            //_rightHand.weight = 0;
        }

        public void SetPlayerAimRigWeight()
        {
            if (_isAimActive == true)
            {
                //_playerAim.weight += Time.deltaTime / _aimDuration;
            }
            else
            {
                //_playerAim.weight -= Time.deltaTime / _aimDuration;
            }
        }

        private void SetPlayerHandsMultiConstraintWeight()
        {
            if (_isHandsConstraintActive == true)
            {
                _leftHand.weight += Time.deltaTime / _aimDuration;
                _rightHand.weight += Time.deltaTime / _aimDuration;
            }
            else
            {
                _leftHand.weight -= Time.deltaTime / _aimDuration;
                _rightHand.weight -= Time.deltaTime / _aimDuration;

            }
        }

        public void SetZoomInFieldOfView()
        {
            _playerFollowCamera.m_Lens.FieldOfView = _cameraZoomInFieldOfView;
        }

        public void SetZoomOutFieldOfView()
        {
            _playerFollowCamera.m_Lens.FieldOfView = _cameraZoomOutFieldOfView;
        }

        public void SetCameraToMovePlayer()
        {
            float yawCamera = _mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), _turnSpeed * Time.deltaTime);
        }

        private void Update()
        {
            //SetPlayerHandsMultiConstraintWeight();
            //SetPlayerAimRigWeight();
            SetCameraToMovePlayer();
        }
    }
}