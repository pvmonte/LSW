using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 MovementVector = new Vector2();
    public bool interactPressed;
    [SerializeField] private KeyCode interactionButton;

    private void Update()
    {
        HandleMovementInput();
        HandleInteractInput();
    }

    public void HandleMovementInput()
    {
        MovementVector.x = Input.GetAxisRaw("Horizontal");

        if (MovementVector.x != 0)
        {
            MovementVector.y = 0;
        }
        else
        {
            MovementVector.y = Input.GetAxisRaw("Vertical");
        }
    }

    public void HandleInteractInput()
    {
        interactPressed = Input.GetKeyDown(interactionButton);
    }

    public void PauseInputs()
    {
        MovementVector = Vector2.zero;
        interactPressed = false;
    }
}
