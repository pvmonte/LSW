using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : InteractableWithMessage
{
    [SerializeField] private CanvasUI shopCanvas;

    protected virtual void Start()
    {
        OnPanelInteraction += OpenShop;
    }

    public override void Interact()
    {
        base.Interact();

    }

    private void OpenShop()
    {
        GameStateController.instance.OpenCanvasUi(shopCanvas);
    }
}
