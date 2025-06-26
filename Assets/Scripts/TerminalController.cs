using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour, IInteractable
{
    public GameObject terminalCanvas;
    public InputField inputField;
    public Text outputText;

    private bool active;

    public void OnInteract()
    {
        terminalCanvas.SetActive(true);
        active = true;
        inputField.text = string.Empty;
        inputField.ActivateInputField();
        LogWriter.Instance.Append("Terminal opened");
    }

    void Update()
    {
        if (!active) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            string cmd = inputField.text;
            inputField.text = string.Empty;
            ExecuteCommand(cmd);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            terminalCanvas.SetActive(false);
            active = false;
        }
    }

    void ExecuteCommand(string cmd)
    {
        LogWriter.Instance.Append($"> {cmd}");
        switch (cmd.ToLower())
        {
            case "help":
                AppendOutput("Commands: help, run.exe, reveal.exit");
                break;
            case "run.exe":
                AppendOutput("running...");
                LoopManager.Instance.StartLoop();
                break;
            case "reveal.exit":
                AppendOutput("Blood trail added");
                // Implementation: enable trail in hallway
                break;
            default:
                AppendOutput("Unknown command");
                break;
        }
    }

    void AppendOutput(string line)
    {
        outputText.text += "\n" + line;
    }
}
