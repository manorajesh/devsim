using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class NumberGenerator : MonoBehaviour
{
    public GameObject numberPrefab;
    public int spacing = 100;
    private int screenWidth;
    private int screenHeight;

    private HashSet<Vector2> generatedPositions = new HashSet<Vector2>();

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        GenerateInitialNumbers();
    }

    void GenerateInitialNumbers()
    {
        for (int x = -screenWidth; x < screenWidth; x += spacing)
        {
            for (int y = -screenHeight; y < screenHeight; y += spacing)
            {
                CreateNumberAtPosition(new Vector2(x, y));
            }
        }
    }

    void CreateNumberAtPosition(Vector2 position)
    {
        GameObject number = Instantiate(numberPrefab, transform);
        number.GetComponent<RectTransform>().anchoredPosition = position;
        number.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(0, 100).ToString();
        generatedPositions.Add(position);
    }
}
