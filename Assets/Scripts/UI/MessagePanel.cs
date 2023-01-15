using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerNameField;
    [SerializeField] private TextMeshProUGUI speakerMessageField;
    
    void Start()
    {
        var interactables = FindObjectsOfType<InteractableWithMessage>();

        foreach (var interactable in interactables)
        {
            interactable.OnInteract += Interactables_OnInteract;
        }

        gameObject.SetActive(false);
    }

    private void Interactables_OnInteract(string name, string message)
    {
        speakerNameField.text = name;
        speakerMessageField.text = message;

        BaseGameState readingState = new ReadingGameState(GameStateController.instance);
        GameStateController.instance.StartNewState(readingState);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        speakerNameField.text = "";
        speakerMessageField.text = "";
        GameStateController.instance.ResetState();
    }
}
