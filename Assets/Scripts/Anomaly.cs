using UnityEngine;

public class Anomaly : MonoBehaviour, IInteractable
{
    [TextArea]
    public string description;
    public bool active;
    public bool discovered;

    public void Activate()
    {
        active = true;
        // Example change: rotate object slightly
        transform.Rotate(0, Random.Range(0, 360), 0);
    }

    public void Deactivate()
    {
        active = false;
        discovered = false;
    }

    public void OnInteract()
    {
        if (active && !discovered)
        {
            discovered = true;
            LoopManager.Instance.CaughtAnomaly(this);
        }
    }
}
