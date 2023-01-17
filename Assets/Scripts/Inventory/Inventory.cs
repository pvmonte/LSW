using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryWindow inventoryWindow;
    [SerializeField] private Hat equipedHat;
    [SerializeField] private Shirt equipedShirt;
    [SerializeField] private List<Item> items = new List<Item>();
    [field: SerializeField] public int coins { get; private set; }
    private InventorySlot selectedSlot;

    public event Action<Item> OnEquip;

    private void Start()
    {
        inventoryWindow.SetCoins(coins);

        if (equipedHat)
            EquipHat(equipedHat);

        if (equipedShirt)
            EquipShirt(equipedShirt);

        for (int i = 0; i < items.Count; i++)
        {
            inventoryWindow.bagSlots[i].FillSlot(items[i]);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        int index = items.Count - 1;
        inventoryWindow.bagSlots[index].FillSlot(item);
    }

    public void RemoveItem(Item item)
    {
        int index = items.IndexOf(item);
        items.Remove(item);
        inventoryWindow.bagSlots[index].ClearSlot();
    }

    public void SelectSlot(InventorySlot slot)
    {
        selectedSlot = slot;
    }

    public void Equip()
    {
        if (selectedSlot.Item is Hat)
        {
            EquipHat(selectedSlot.Item as Hat);
        }
        else
        {
            EquipShirt(selectedSlot.Item as Shirt);
        }

        OnEquip?.Invoke(selectedSlot.Item);
    }

    public void EquipHat(Hat hat)
    {
        equipedHat = hat;
        equipedHat.equiped = true;
        inventoryWindow.hatSlot.FillSlot(equipedHat);
    }

    public void EquipShirt(Shirt shirt)
    {
        equipedShirt = shirt;
        equipedShirt.equiped = true;
        inventoryWindow.shirtSlot.FillSlot(equipedShirt);
    }

    public void Buy(Item item)
    {
        AddItem(item);
        coins -= item.price;
        inventoryWindow.SetCoins(coins);
    }

    public void Sell()
    {
        if (selectedSlot == null) return;

        Item soldItem = selectedSlot.Item;

        if (soldItem.equiped) return;

        RemoveItem(soldItem);
        coins += soldItem.price / 2;
        inventoryWindow.SetCoins(coins);
        selectedSlot = null;
    }
}
