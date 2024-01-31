using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    /// <summary>
    /// Inherritance IPlayerActions
    /// IPlayerActions is interface of InputActions, use this to override method from InputActions
    /// </summary>

    public event Action<Vector2> MoveEvent;
    public event Action<bool> PrimaryFireEvent;
    private Controls controls;

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
        }

        controls.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        if (context.performed) // .performed is pressed
        {
            // ?. to check if null
            PrimaryFireEvent?.Invoke(true);
        }
        else if (context.canceled) // .canceled is not pressed
        {
            // ?. to check if null
            PrimaryFireEvent?.Invoke(false);
        }
    }
}