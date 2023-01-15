using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    [SerializeField] private float speed = 1;
    private Animator anim;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private InteractableObject interactable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        SetAniamtions();
    }

    private void SetAniamtions()
    {
        anim.SetFloat("horizontal", movementInput.x);
        anim.SetFloat("vertical", movementInput.y);
        anim.SetFloat("speed", movementInput.sqrMagnitude);
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        interactable?.Interact();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactable = collision.gameObject.GetComponent<InteractableObject>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObject>() == interactable)
            interactable = null;
    }
}
