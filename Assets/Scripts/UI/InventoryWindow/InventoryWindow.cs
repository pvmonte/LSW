using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryWindow : MonoBehaviour
{
    [field: SerializeField] public InventorySlot hatSlot { get; private set; }
    [field: SerializeField] public InventorySlot shirtSlot { get; private set; }
    [field: SerializeField] public List<InventorySlot> bagSlots { get; private set; } = new List<InventorySlot>();

    [SerializeField] private Button equipButton;

    public void Start()
    {
        for (int i = 0; i < bagSlots.Count; i++)
        {
            bagSlots[i].Setup(i);
        }
    }
}
