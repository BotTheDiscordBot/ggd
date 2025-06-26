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
        // Random subtle change
        int mode = Random.Range(0, 3);
        switch (mode)
        {
            case 0:
                transform.Rotate(0, Random.Range(0, 360), 0);
                break;
            case 1:
                transform.localScale *= Random.Range(0.8f, 1.2f);
                break;
            case 2:
                var renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(Random.value, Random.value, Random.value);
                }
                break;
        }
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
