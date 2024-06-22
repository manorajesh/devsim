using TMPro;

public static class ConsoleUtils
{
    public static void AddLine(TextMeshProUGUI consoleText, string newLine, int maxLines)
    {
        string[] lines = consoleText.text.Split('\n');

        if (lines.Length >= maxLines)
        {
            // Remove the oldest line
            consoleText.text = string.Join("\n", lines, 1, lines.Length - 1);
        }

        consoleText.text += newLine + "\n";
    }
}
