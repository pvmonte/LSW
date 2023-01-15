using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryWindow inventoryWindow;
    [SerializeField] private Hat equipedHat;
    [SerializeField] private Shirt equipedShirt;
    [SerializeField] private List<Item> items = new List<Item>();

    private InventorySlot selectedSlot;

    private void Start()
    {
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
        int index = items.IndexOf(item);
        items.Add(item);
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
            return;
        }

        EquipShirt(selectedSlot.Item as Shirt);
    }

    public void EquipHat(Hat hat)
    {
        equipedHat = hat;
        inventoryWindow.hatSlot.FillSlot(equipedHat);
    }

    public void EquipShirt(Shirt shirt)
    {
        equipedShirt = shirt;
        inventoryWindow.shirtSlot.FillSlot(equipedShirt);
    }

    public bool Contains(Item item)
    {
        return items.Contains(item);
    }
}
