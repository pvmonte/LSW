using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : InteractableWithMessage
{
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
        print("openShop");
    }
}
