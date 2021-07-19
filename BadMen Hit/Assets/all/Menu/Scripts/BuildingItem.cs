using UnityEngine;
using TMPro;

public class BuildingItem : Item //xmenbro
{
    [SerializeField] private TextMeshProUGUI _itemText;

    private void Start() => _itemText.text = $"{_itemData.Name} {_itemData.Price} {_itemData.CurrencyType}";
}
