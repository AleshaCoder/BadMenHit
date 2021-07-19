using UnityEngine;

public abstract class Keeper : MonoBehaviour //xmenbro
{ 
    public void Save(ItemData itemData) => PlayerPrefs.SetInt(itemData.Name, 1);

    protected void Clear() => PlayerPrefs.DeleteAll();
}
