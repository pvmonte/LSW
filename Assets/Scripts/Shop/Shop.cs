using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Item> itemsForSale;
    [SerializeField] private ShopSlot slotPrefab;
    [SerializeField] private RectTransform slotsParent;

    [SerializeField] private List<ShopSlot> slots;
    [SerializeField] private Button sellButton;

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

        sellButton.onClick.AddListener(Sell);
    }

    private void Slot_OnClickBuyButton(int index)
    {
        ShopSlot slot = slots[index];

        if (slot.slotItem.price > playerInventory.coins) return;

        Item item = Buy(index, slot);
        playerInventory.Buy(item);
    }

    public Item Buy(int slotIndex, ShopSlot slot)
    {
        Destroy(slot.gameObject);
        slots[slotIndex] = null;
        itemsForSale[slotIndex] = null;
        return slot.slotItem;
    }

    public void Sell()
    {
        playerInventory.Sell();
    }
}
