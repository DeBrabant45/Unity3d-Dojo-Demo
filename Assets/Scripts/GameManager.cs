using AD.Player;
using AD.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] UIPauseMenu _uIPauseMenu;
         
    private void Update()
    {
        if (_playerInput.IsEscapeKeyPressed())
        {
            _uIPauseMenu.SetMenuPanelActive();
        }
    }
}