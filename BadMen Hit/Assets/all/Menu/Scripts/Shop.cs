using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour //xmenbro
{
    [SerializeField] private CurrencyData _currencyDataSouls;
    [SerializeField] private CurrencyData _currencyDataReputation;
    [SerializeField] private ItemKeeper _itemKeeper;

    public delegate void Action();
    public event Action OnItemBought;

    public void Buy(ItemData itemData)
    {
        switch (itemData.CurrencyType)
        {
            case ItemData.Currency.Souls:
                Pay(_currencyDataSouls, itemData);
                break;
            case ItemData.Currency.Reputation:
                Pay(_currencyDataReputation, itemData);
                break;
        }
    }

    private void Pay(CurrencyData currencyData, ItemData itemData)
    {
        bool isBought = PlayerPrefs.HasKey(itemData.Name);

        if (currencyData.Count >= itemData.Price && !isBought)
        {
            currencyData.AcceptPayment(itemData);
            OnItemBought?.Invoke();
            _itemKeeper.Save(itemData);
            Debug.Log("Куплено");
        }
        else
            Debug.Log("Ошибка");
    }
}
