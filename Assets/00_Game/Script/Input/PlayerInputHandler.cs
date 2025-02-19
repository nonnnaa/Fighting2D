using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput;
    public bool isJump {  get; private set; }
    public bool isDash {  get; private set; }
    public bool isAttack {  get; private set; }

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
    public void OnRightMouse(InputAction.CallbackContext context)
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
    public void OnLeftMouse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttack = true;
        }
        if(context.canceled)
        {
            isAttack= false;
        }
    }

}
