using UnityEngine;

public abstract class ItemData : ScriptableObject //xmenbro
{
    [SerializeField] protected int _price;
    [SerializeField] protected string _name;
    public enum Currency { Souls, Reputation}
    public Currency CurrencyType;

    public int Price { get { return _price; } }
    public string Name { get { return _name; } }
}
