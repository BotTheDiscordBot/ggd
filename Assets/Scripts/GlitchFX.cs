using UnityEngine;
// Optional post-processing volume component. The game will still compile if
// no post-processing package is installed because we reference it via
// the generic Behaviour type.
using System.Reflection;

public class GlitchFX : MonoBehaviour
{
    // This can reference a PostProcessVolume or any other component that has a
    // 'weight' property (e.g. Volume from URP). Using Behaviour keeps the script
    // flexible and avoids compile errors if no post-processing package is present.
    public Behaviour volume;
    public AudioSource whisperSource;
    public AudioClip[] whispers;
    public GameObject watcherPrefab;

    private float paranoiaLevel;

    public void IncreaseParanoia(float amount)
    {
        paranoiaLevel = amount;
        if (volume != null)
        {
            // Attempt to set a "weight" property on the component if it exists.
            var prop = volume.GetType().GetProperty("weight", BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(volume, Mathf.Clamp01(paranoiaLevel / 10f), null);
            }
            else
            {
                volume.enabled = paranoiaLevel > 0.1f;
            }
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
