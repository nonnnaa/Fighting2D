using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput;
    public bool isJump;
    public bool isDash;
    private void Start()
    {
        
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isJump = true;
        }
        if (context.canceled)
        {
            isJump = false;
        }
    }
    public void OnRunInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnLeftMouse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isDash = true;
        }
        if (context.canceled)
        {
            isDash = false;
        }
    }
}
