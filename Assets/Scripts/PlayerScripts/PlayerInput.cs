using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _mainCamera;
    private float _previousPrimaryActionInput = 0;
    private float _previousSecondaryActionInput = 0;

    public Vector2 MovementInputVector { get; private set; }
    public Vector3 MovementDirectionVector { get; private set; }


    private void Awake()
    {
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CheckMenuButton();
        GetMovementInput();
        GetMovementDirection();
        IsJumpInput();
        IsPrimaryAction();
        IsSecondaryClickAction();
        IsSecondaryHeldDownAction();
        IsSecondaryUpAction();
        IsShiftKeyPressed();
    }

    public bool IsSecondaryUpAction()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return true;
        }
        return false;
    }

    public bool IsSecondaryHeldDownAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return true;
        }
        return false;
    }

    public bool CheckMenuButton()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }
        return false;
    }

    public bool IsSecondaryClickAction()
    {
        var inputValue = Input.GetAxisRaw("Fire2");
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
        var inputValue = Input.GetAxisRaw("Fire1");
        if(_previousPrimaryActionInput == 0)
        {
            if(inputValue >= 1)
            {
                return true;
            }
        }
        _previousPrimaryActionInput = inputValue;
        return false;
    }

    public bool IsShiftKeyPressed()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            return true;
        }
        return false;
    }

    public bool IsJumpInput()
    {
        if(Input.GetAxisRaw("Jump") > 0)
        {
            return true;
        }
        return false;
    }

    private void GetMovementDirection()
    {
        var cameraForwardDirection = _mainCamera.transform.forward;
        MovementDirectionVector = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
    }

    private void GetMovementInput()
    {
        MovementInputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
