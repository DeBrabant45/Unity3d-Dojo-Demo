using System.Collections;
using AD.Interfaces;
using AD.Player;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AD.PlayModeTests
{
    [TestFixture]
    public class PlayerInputTests
    {
        private PlayerInput _playerInput;
        private IUnityInputService _unityInputService;

        [SetUp]
        public void Setup()
        {
            var mainCamera = new GameObject().AddComponent<Camera>();
            mainCamera.tag = "MainCamera";
            _playerInput = new GameObject().AddComponent<PlayerInput>();
            _unityInputService = Substitute.For<IUnityInputService>();
            _playerInput.UnityInputService = _unityInputService;
        }

        [UnityTest]
        public IEnumerator IsRKeyPressed_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.R).Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsRKeyPressed());
        }

        [UnityTest]
        public IEnumerator IsRKeyPressed_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.T).Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsRKeyPressed());
        }

        [UnityTest]
        public IEnumerator IsPrimaryActionPressed_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetAxisRawPressedDown("Fire1").Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsPrimaryActionPressed());
        }

        [UnityTest]
        public IEnumerator IsPrimaryActionPressed_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetAxisRawPressedDown("Fire2").Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsPrimaryActionPressed());
        }

        [UnityTest]
        public IEnumerator IsSecondaryActionPressed_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetAxisRawPressedDown("Fire2").Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsSecondaryActionPressed());
        }

        [UnityTest]
        public IEnumerator IsSecondaryActionPressed_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetAxisRawPressedDown("Fire3").Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsSecondaryActionPressed());
        }

        [UnityTest]
        public IEnumerator IsSpacebarPressed_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.Space).Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsSpacebarPressed());
        }

        [UnityTest]
        public IEnumerator IsSpacebarPressed_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.N).Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsSpacebarPressed());
        }

        [UnityTest]
        public IEnumerator IsShiftKeyPressed_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.LeftShift).Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsShiftKeyPressed());
        }

        [UnityTest]
        public IEnumerator IsShiftKeyPressed_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.RightShift).Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsShiftKeyPressed());
        }

        [UnityTest]
        public IEnumerator IsEscapeKeyPressed_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.Escape).Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsEscapeKeyPressed());
        }

        [UnityTest]
        public IEnumerator IsEscapeKeyPressed_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.Delete).Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsEscapeKeyPressed());
        }

        [UnityTest]
        public IEnumerator IsSecondaryHeldDownAction_ValidKeyPressed_ReturnsTrue()
        {
            _unityInputService.GetMouseButton(1).Returns(true);
            yield return null;
            Assert.IsTrue(_playerInput.IsSecondaryHeldDownAction());
        }

        [UnityTest]
        public IEnumerator IsSecondaryHeldDownAction_InvalidKeyPressed_ReturnsFalse()
        {
            _unityInputService.GetMouseButton(2).Returns(true);
            yield return null;
            Assert.IsFalse(_playerInput.IsSecondaryHeldDownAction());
        }

        [TearDown]
        public void Terminate()
        {
            GameObject.Destroy(_playerInput);
        }
    }
}