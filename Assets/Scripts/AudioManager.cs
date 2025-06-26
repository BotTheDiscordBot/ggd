using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ambienceSource;
    public AudioClip loopAmbience;
    public AudioClip[] randomWhispers;

    public void PlayLoopAmbience()
    {
        if (!ambienceSource.isPlaying)
        {
            ambienceSource.clip = loopAmbience;
            ambienceSource.loop = true;
            ambienceSource.Play();
        }
    }

    public void PlayRandomWhisper()
    {
        if (randomWhispers.Length == 0) return;
        ambienceSource.PlayOneShot(randomWhispers[Random.Range(0, randomWhispers.Length)]);
    }
}
