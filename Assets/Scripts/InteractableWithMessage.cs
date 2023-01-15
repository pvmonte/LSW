using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithMessage : InteractableObject
{
    [SerializeField] protected bool useObjectName = true;
    [SerializeField] protected string message;

    protected Action OnPanelInteraction;
    public event Action<string, string, Action> OnInteract;

    public override void Interact()
    {
        string name = useObjectName ? gameObject.name : "";
        OnInteract?.Invoke(name, message, OnPanelInteraction);
    }
}
