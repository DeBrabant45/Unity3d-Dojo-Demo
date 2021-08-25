using System.Collections;
using AD.Animation;
using AD.Interfaces;
using AD.Player;
using AD.StateMachine.Player;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AD.PlayModeTests.StateMachine.Player.Decision
{
    [TestFixture]
    public class ArmedStanceDecisionTests
    {
        private PlayerStateController _playerController;
        private IUnityInputService _unityInputService;
        private PlayerState _startState;
        private PlayerState _trueState;
        private PlayerState _falseState;

        [SetUp]
        public void Setup()
        {
            _playerController = new GameObject().AddComponent<PlayerStateController>();
            Camera mainCamera = new GameObject().AddComponent<Camera>();
            mainCamera.tag = "MainCamera";
            PlayerInput playerInput = new GameObject().AddComponent<PlayerInput>();
            _unityInputService = Substitute.For<IUnityInputService>();

            _startState = ScriptableObject.CreateInstance<PlayerState>();
            _trueState = ScriptableObject.CreateInstance<PlayerState>();
            _falseState = ScriptableObject.CreateInstance<PlayerState>();

            ArmedStanceDecision armedStance = ScriptableObject.CreateInstance<ArmedStanceDecision>();
            PlayerTransition[] playerTransitions = { new PlayerTransition(armedStance, _trueState, _falseState) };

            _startState.Constructor(null, playerTransitions);
            _playerController.Constructor(_startState, _falseState, playerInput);
            playerInput.Constructor(_unityInputService);
        }

        [UnityTest]
        public IEnumerator Decide_ValidDecisionMade_ReturnsTrue()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.R).Returns(true);
            yield return null;
            Assert.IsTrue(_playerController.CurrentState == _trueState);
        }

        [UnityTest]
        public IEnumerator Decide_InvalidDecisionMade_ReturnsFalse()
        {
            _unityInputService.GetKeyButtonPressedDown(KeyCode.G).Returns(true);
            yield return null;
            Assert.IsFalse(_playerController.CurrentState == _trueState);
        }

        [TearDown]
        public void Terminate()
        {
            GameObject.Destroy(_playerController);
            GameObject.Destroy(_startState);
            GameObject.Destroy(_trueState);
            GameObject.Destroy(_falseState);
        }
    }
}