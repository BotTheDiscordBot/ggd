using System.Collections.Generic;
using UnityEngine;

public class AnomalyTracker : MonoBehaviour
{
    public List<Anomaly> anomalies = new List<Anomaly>();
    private Anomaly current;

    public void TriggerNewAnomaly()
    {
        if (current != null) current.Deactivate();

        if (anomalies.Count == 0) return;
        int index = Random.Range(0, anomalies.Count);
        current = anomalies[index];
        current.Activate();
    }

    public bool HasActiveAnomaly()
    {
        return current != null && current.active;
    }
}
