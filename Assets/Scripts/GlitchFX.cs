using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlitchFX : MonoBehaviour
{
    public PostProcessVolume volume;
    public AudioSource whisperSource;
    public AudioClip[] whispers;
    public GameObject watcherPrefab;

    private float paranoiaLevel;

    public void IncreaseParanoia(float amount)
    {
        paranoiaLevel = amount;
        if (volume != null)
        {
            volume.weight = Mathf.Clamp01(paranoiaLevel / 10f);
        }
        if (Random.value < 0.5f && whispers.Length > 0)
        {
            whisperSource.pitch = Random.Range(0.8f, 1.2f);
            whisperSource.PlayOneShot(whispers[Random.Range(0, whispers.Length)]);
        }
    }

    public void TriggerJumpScare()
    {
        // Example implementation: play loud audio, flash screen
        Debug.Log("JUMPSCARE!");
    }

    public void ShowWatcher()
    {
        if (watcherPrefab != null)
        {
            Instantiate(watcherPrefab, transform.position + transform.forward * 10f, Quaternion.identity);
        }
    }
}
