using UnityEngine;

public class BloodTrail : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Reveal()
    {
        gameObject.SetActive(true);
    }
}
