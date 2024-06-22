using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class BootupSequence : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public float scrollSpeed = 0.1f;
    public float pauseOnHeaderLength = 0.5f;
    public float randomDelay = 0.1f;
    public int maxLines = 20;
    public string bootupFilePath = "Assets/Scenes/StartingMenu/BootupText.txt";

    public delegate void BootupCompleteHandler();
    public event BootupCompleteHandler OnBootupComplete;

    void Start()
    {
        StartCoroutine(ShowBootupSequence());
    }

    IEnumerator ShowBootupSequence()
    {
        consoleText.text = "";
        string bootupText = ReadBootupText();
        string[] bootupLines = bootupText.Split('\n');

        foreach (string line in bootupLines)
        {
            ConsoleUtils.AddLine(consoleText, line, maxLines);
            float delay = line.Contains("...") && !line.Contains("[") ? pauseOnHeaderLength : scrollSpeed;
            yield return new WaitForSeconds(delay + Random.Range(0.0f, randomDelay));
        }

        yield return new WaitForSeconds(1f);

        OnBootupComplete?.Invoke();
    }

    string ReadBootupText()
    {
        if (File.Exists(bootupFilePath))
        {
            return File.ReadAllText(bootupFilePath);
        }
        else
        {
            Debug.LogError("Bootup text file not found at: " + bootupFilePath);
            return string.Empty;
        }
    }
}
