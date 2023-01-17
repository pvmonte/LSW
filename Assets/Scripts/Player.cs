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

    private IInteractable interactable;

    [SerializeField] private Transform hatSlot;
    [SerializeField] private Transform shirtSlot;

    // Start is called before the first frame update
    void Start()
    {
        var inventory = FindObjectOfType<Inventory>(true);
        inventory.OnEquip += Player_OnEquip;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Player_OnEquip(Item item)
    {
        if (item is Hat)
        {
            EquipHat(item as Hat);
            return;
        }

        EquipShirt(item as Shirt);
    }

    // Update is called once per frame
    public void Update()
    {
        SetAniamtions();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
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

        if (context.phase != InputActionPhase.Canceled)
        {
            anim.SetFloat("horizontalIdle", movementInput.x);
            anim.SetFloat("verticalIdle", movementInput.y);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        interactable?.Interact();
    }

    public void EquipHat(Hat hat)
    {
        if (hatSlot.childCount > 0)
        {
            Destroy(hatSlot.GetChild(0).gameObject);
        }

        Instantiate(hat.prefab, hatSlot);
    }

    public void EquipShirt(Shirt shirt)
    {
        if (shirtSlot.childCount > 0)
        {
            Destroy(shirtSlot.GetChild(0).gameObject);
        }

        Instantiate(shirt.prefab, shirtSlot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactable = collision.gameObject.GetComponent<InteractableObject>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() == interactable)
            interactable = null;
    }
}
