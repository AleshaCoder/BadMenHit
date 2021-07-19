using UnityEngine;

public class People : MonoBehaviour //xmenbro
{
    public delegate void Action();

    public event Action OnLightningStrike;

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    private void OnMouseDown()
    {
        OnLightningStrike?.Invoke();
        Destroy(gameObject, 0.5f);
    }
#endif
}
