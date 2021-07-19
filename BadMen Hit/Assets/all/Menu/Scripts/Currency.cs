using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour //xmenbro
{
    [SerializeField] private CurrencyData _currencyData;
    [SerializeField] private Shop _shop;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        ShowCurrencyData();
        _shop.OnItemBought += ShowCurrencyData;
    }

    private void ShowCurrencyData() => _text.text = _currencyData.Count + " " + _currencyData.Name;
}
