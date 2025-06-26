using System.IO;
using UnityEngine;

public class LogWriter : MonoBehaviour
{
    public static LogWriter Instance { get; private set; }
    public string fileName = "log.txt";
    private string path;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            path = Path.Combine(Application.dataPath, "Resources", fileName);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Append(string line)
    {
        File.AppendAllText(path, line + "\n");
    }
}
