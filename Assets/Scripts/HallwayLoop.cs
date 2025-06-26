using UnityEngine;

public class HallwayLoop : MonoBehaviour
{
    public Transform player;
    public Transform startPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            player.position = startPoint.position;
            LoopManager.Instance.PlayerLooped();
        }
    }
}
