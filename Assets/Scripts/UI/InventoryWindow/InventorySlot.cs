using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour
{
    [field: SerializeField] public Image slotIcon { get; private set; }
    [SerializeField] private Sprite defaultSprite;
    [field: SerializeField] public Item Item { get; private set; }
    public int IndexInBag { get; private set; }
    private bool filled;

    private Button btn;

    public void Setup(int index)
    {
        IndexInBag = index;
    }

    public void ClearSlot()
    {
        if (!filled) return;

        slotIcon.sprite = defaultSprite;
        slotIcon.color = new Color(1, 1, 1, 0);
        Item = null;
        filled = false;
    }

    public void FillSlot(Item newItem)
    {
        if (filled) return;

        slotIcon.sprite = newItem.icon;
        slotIcon.color = Color.white;
        Item = newItem;
        filled = true;
    }
}
