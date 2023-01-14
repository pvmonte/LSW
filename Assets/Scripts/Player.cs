using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementVector;
    [SerializeField] private float speed = 1;
    private Animator anim;

    private Interactable interactable;
    [SerializeField] private KeyCode interactionButton;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();

        if (interactable != null && Input.GetKeyDown(interactionButton))
        {
            interactable.Interact();
        }

        SetAniamtions();
    }

    private void HandleMovementInput()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");

        if (movementVector.x != 0)
        {
            movementVector.y = 0;
        }
        else
        {
            movementVector.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void SetAniamtions()
    {
        anim.SetFloat("horizontal", movementVector.x);
        anim.SetFloat("vertical", movementVector.y);
        anim.SetFloat("speed", movementVector.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.velocity = movementVector * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactable = collision.gameObject.GetComponent<Interactable>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() == interactable)
            interactable = null;
    }
}
