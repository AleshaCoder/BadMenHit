using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour //xmenbro
{
    private float _fps;
    [SerializeField] private TextMeshProUGUI _fpsText;

    private void Update()
    {
        if (_fpsText.gameObject.activeSelf)
        {
            _fps = 1.0f / Time.deltaTime;
            _fpsText.text = "" + (int)_fps;
        }
    }
}
