using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject emailPanel;
    public GameObject refiningPanel;
    public GameObject entryPanel;

    public Button emailTabButton;
    public Button refiningTabButton;
    public Button entryTabButton;

    private GameObject currentPanel;

    void Start()
    {
        emailTabButton.onClick.AddListener(() => ShowPanel(emailPanel));
        refiningTabButton.onClick.AddListener(() => ShowPanel(refiningPanel));
        entryTabButton.onClick.AddListener(() => ShowPanel(entryPanel));

        ShowPanel(refiningPanel);
    }

    void ShowPanel(GameObject panelToShow)
    {
        // Hide all panels
        emailPanel.SetActive(false);
        refiningPanel.SetActive(false);
        entryPanel.SetActive(false);

        // Show the selected panel
        panelToShow.SetActive(true);
        currentPanel = panelToShow;

        selectButton();
    }

    void selectButton()
    {
        // Set the selected tab button to be highlighted
        switch (currentPanel.name)
        {
            case "EmailPanel":
                emailTabButton.Select();
                break;
            case "RefiningPanel":
                refiningTabButton.Select();
                break;
            case "EntryPanel":
                entryTabButton.Select();
                break;
        }
    }

    void Update()
    {
        // Check for keyboard input to switch between tabs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowPanel(refiningPanel);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowPanel(emailPanel);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowPanel(entryPanel);
        }

        selectButton();
    }
}
