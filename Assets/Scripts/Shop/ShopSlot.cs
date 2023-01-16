using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI priceLabel;
    [SerializeField] private Button buyButton;
    public Item slotItem { get; private set; }
    private int indexInShop;

    public event Action<int> OnClickBuyButton;

    public void Initilize(Item item, int index)
    {
        slotItem = item;
        itemIcon.sprite = item.icon;
        priceLabel.text = item.price.ToString();
        buyButton.onClick.AddListener(BuyButtonClick);
        indexInShop = index;
    }

    private void BuyButtonClick()
    {
        OnClickBuyButton?.Invoke(indexInShop);
    }

}
