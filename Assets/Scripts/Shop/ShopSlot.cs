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

    private void Start()
    {
        
    }

    public void Initilize(Item item, int index)
    {
        slotItem = item;
        itemIcon.sprite = item.icon;
        priceLabel.text = item.price.ToString();
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        buyButton.onClick.AddListener(BuyButtonClick);
        buyButton.onClick.AddListener(audioManager.PlayUIClick);
        indexInShop = index;
    }

    private void BuyButtonClick()
    {
        OnClickBuyButton?.Invoke(indexInShop);
    }

}
