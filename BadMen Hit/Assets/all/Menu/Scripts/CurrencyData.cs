using UnityEngine;

[CreateAssetMenu(fileName = "New CurrencyData", menuName = "Currency Data", order = 51)]
public class CurrencyData : ScriptableObject //xmenbro
{
    [SerializeField] private int _count;
    [SerializeField] private string _name;

    public int Count { get { return _count; } }
    public string Name { get { return _name; } }

    public void AcceptPayment(ItemData itemData) => _count -= itemData.Price;
}