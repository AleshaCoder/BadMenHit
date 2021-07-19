using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour //xmenbro
{
    [SerializeField] private AudioMixer _audioMixer;

    public delegate void Action();

    public static event Action OnStart;
    public static event Action OnPause;

    public static bool Active { get; private set; } = true;

    public void StartGame()
    {
        Active = false;
    }

    public void PauseGame()
    {
        Active = true;
    }

    public void SetVolume(float volume) => _audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);

    public void SetGraphicsQuality(int qualityIndex) => QualitySettings.SetQualityLevel(qualityIndex);
}
