using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public BootupSequence bootupSequence;
    public string[] menuOptions = { "./play", "cat .gameconfig", "shutdown now" };
    public int selectedOption = 0;
    public Color selectedOptionColor = Color.yellow;
    public Color unselectedOptionColor = Color.gray;
    public string selectedOptionPrefix = "dev@desktopA2S01:~$";
    public string lastLogin;

    private void Start()
    {
        lastLogin = PlayerPrefs.GetString("LastLogin", "Never");
        PlayerPrefs.SetString("LastLogin", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        PlayerPrefs.Save();
    }

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
        HandleInput();
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
        consoleText.text = "Last login: " + lastLogin + "\n\n";

        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == selectedOption)
            {
                // Applying a highlight background color, modify color and style as needed
                // consoletext.text += "<mark=" + selectedoptioncolor + ">  " + menuoptions[i] + "</mark>\n";

                consoleText.text += selectedOptionPrefix + " " + menuOptions[i] + "\n";
            }
            else
            {
                consoleText.text += "<color=#" + unselectedOptionColor.ToHexString() + ">" + new string(' ', selectedOptionPrefix.Length+1) + menuOptions[i] + "</color>\n";
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
