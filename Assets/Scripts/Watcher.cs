using UnityEngine;

public class Watcher : MonoBehaviour
{
    private Transform player;
    public float lifeTime = 5f;
    private float timer;

    void Start()
    {
        player = Camera.main.transform;
        timer = lifeTime;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
