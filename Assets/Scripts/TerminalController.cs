using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour, IInteractable
{
    public GameObject terminalCanvas;
    public InputField inputField;
    public Text outputText;
    public BloodTrail bloodTrail;

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
                AppendOutput("Commands: help, run.exe, reveal.exit, spawn.watcher, set.paranoia <v>");
                break;
            case "run.exe":
                AppendOutput("running...");
                LoopManager.Instance.StartLoop();
                break;
            case "reveal.exit":
                AppendOutput("Blood trail added");
                bloodTrail?.Reveal();
                break;
            case "spawn.watcher":
                LoopManager.Instance.glitch.ShowWatcher();
                AppendOutput("It is watching now");
                break;
            default:
                if (cmd.StartsWith("set.paranoia"))
                {
                    var parts = cmd.Split(' ');
                    if (parts.Length > 1 && float.TryParse(parts[1], out float val))
                    {
                        LoopManager.Instance.paranoia = val;
                        LoopManager.Instance.glitch.IncreaseParanoia(val);
                        AppendOutput($"Paranoia set to {val}");
                    }
                    else
                    {
                        AppendOutput("Usage: set.paranoia <value>");
                    }
                }
                else
                {
                    AppendOutput("Unknown command");
                }
                break;
        }
    }

    void AppendOutput(string line)
    {
        outputText.text += "\n" + line;
        LogWriter.Instance.Append(line);
    }
}
