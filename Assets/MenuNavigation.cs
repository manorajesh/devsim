using TMPro;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public BootupSequence bootupSequence;
    public string[] menuOptions = { "Play", "Options", "Exit" };
    public int selectedOption = 0;

    void OnEnable()
    {
        bootupSequence.OnBootupComplete += ShowMenu;
    }

    void OnDisable()
    {
        bootupSequence.OnBootupComplete -= ShowMenu;
    }

    void Update()
    {
        if (bootupSequence == null || !bootupSequence.isActiveAndEnabled)
        {
            HandleInput();
        }
    }

    void ShowMenu()
    {
        DisplayMenu();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedOption = (selectedOption - 1 + menuOptions.Length) % menuOptions.Length;
            DisplayMenu();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedOption = (selectedOption + 1) % menuOptions.Length;
            DisplayMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectOption();
        }
    }

    void DisplayMenu()
    {
        consoleText.text = "";

        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == selectedOption)
            {
                consoleText.text += "> " + menuOptions[i] + "\n";
            }
            else
            {
                consoleText.text += "  " + menuOptions[i] + "\n";
            }
        }
    }

    void SelectOption()
    {
        switch (menuOptions[selectedOption])
        {
            case "Play":
                // Start the game
                Debug.Log("Play selected");
                break;
            case "Options":
                // Open options menu
                Debug.Log("Options selected");
                break;
            case "Exit":
                // Exit the game
                Debug.Log("Exit selected");
                Application.Quit();
                break;
        }
    }
}
