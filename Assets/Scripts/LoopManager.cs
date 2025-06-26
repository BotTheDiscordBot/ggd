using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopManager : MonoBehaviour
{
    public static LoopManager Instance { get; private set; }

    public int loopCount;
    public int successfulStreak;
    public int failedNotices;
    public float paranoia;

    public AnomalyTracker tracker;
    public GlitchFX glitch;
    public AudioManager audioManager;
    public LogWriter logger;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartLoop();
    }

    public void StartLoop()
    {
        loopCount++;
        logger.Append($"Loop {loopCount} started");
        tracker.TriggerNewAnomaly();
        audioManager.PlayLoopAmbience();
        if (Random.value < 0.2f)
        {
            glitch.ShowWatcher();
        }
    }

    public void CaughtAnomaly(Anomaly a)
    {
        successfulStreak++;
        failedNotices = 0;
        logger.Append($"Caught anomaly: {a.name}");
        if (successfulStreak >= 3)
        {
            UnlockPath();
            successfulStreak = 0;
        }
        StartLoop();
    }

    public void MissedAnomaly()
    {
        failedNotices++;
        successfulStreak = 0;
        paranoia += 1f;
        glitch.IncreaseParanoia(paranoia);
        logger.Append("Missed anomaly");
        if (failedNotices >= 5)
        {
            glitch.TriggerJumpScare();
            failedNotices = 0;
        }
        StartLoop();
    }

    public void PlayerLooped()
    {
        if (tracker.HasActiveAnomaly())
        {
            MissedAnomaly();
        }
        else
        {
            StartLoop();
        }
    }

    void UnlockPath()
    {
        logger.Append("Path unlocked");
        // Implementation detail: enable a door, open elevator, etc.
    }
}
