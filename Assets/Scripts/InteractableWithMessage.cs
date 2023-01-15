using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithMessage : InteractableObject
{
    [SerializeField] private bool useObjectName;
    [SerializeField] private string message;

    public event Action<string, string> OnInteract;

    public override void Interact()
    {
        string name = useObjectName ? gameObject.name : "";
        OnInteract?.Invoke(name, message);
    }
}
