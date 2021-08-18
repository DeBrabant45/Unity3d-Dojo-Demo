using System.Collections;
using AD.Interfaces;
using AD.Player;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerInputTests
{
    private PlayerInput _playerInput;
    private IPlayerInputService _playerInputService;

    [SetUp]
    public void Setup()
    {
        var mainCamera = new GameObject().AddComponent<Camera>();
        mainCamera.tag = "MainCamera";
        _playerInput = new GameObject().AddComponent<PlayerInput>();
        _playerInputService = Substitute.For<IPlayerInputService>();
        _playerInput.PlayerInputService = _playerInputService;
    }

    [UnityTest]
    public IEnumerator IsRKeyPressed_ValidKeyPressed_ReturnsTrue()
    {
        _playerInputService.GetKeyButtonPressedDown(KeyCode.R).Returns(true);
        yield return null;
        Assert.IsTrue(_playerInput.IsRKeyPressed());
    }

    [UnityTest]
    public IEnumerator IsRKeyPressed_InvalidKeyPressed_ReturnsFalse()
    {
        _playerInputService.GetKeyButtonPressedDown(KeyCode.T).Returns(true);
        yield return null;
        Assert.IsFalse(_playerInput.IsRKeyPressed());
    }
}
