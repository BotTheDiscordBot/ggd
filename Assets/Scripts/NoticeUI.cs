using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    public Text noticeText;
    public float displayTime = 2f;
    private float timer;

    public void Show(string message)
    {
        noticeText.text = message;
        noticeText.gameObject.SetActive(true);
        timer = displayTime;
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                noticeText.gameObject.SetActive(false);
            }
        }
    }
}
