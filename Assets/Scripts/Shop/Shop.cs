using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Item> itemsForSale;
    [SerializeField] private ShopSlot slotPrefab;
    [SerializeField] private RectTransform slotsParent;

    [SerializeField] private List<ShopSlot> slots;

    private Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = FindObjectOfType<Inventory>(true);

        for (int i = 0; i < itemsForSale.Count; i++)
        {
            ShopSlot slot = Instantiate(slotPrefab, slotsParent);
            slot.Initilize(itemsForSale[i], i);
            slot.OnClickBuyButton += Slot_OnClickBuyButton;
            slots.Add(slot);
        }

        Vector2 slotsParentSize = slotsParent.sizeDelta;
        slotsParentSize.y = slotsParent.childCount * 110;
        slotsParent.sizeDelta = slotsParentSize;
    }

    private void Slot_OnClickBuyButton(int index)
    {
        Item item = Buy(index);
        playerInventory.AddItem(item);
    }

    public Item Buy(int slotIndex)
    {
        ShopSlot slot = slots[slotIndex];
        Destroy(slot.gameObject);
        slots.Remove(slot);
        itemsForSale.RemoveAt(slotIndex);
        return slot.slotItem;
    }
}
