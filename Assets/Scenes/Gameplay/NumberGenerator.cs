using System.Collections;
using UnityEngine;
using TMPro;

public class NumberGenerator : MonoBehaviour
{
    public GameObject numberPrefab;
    public int numberCount = 100;
    public int screenWidth = 1280;
    public int screenHeight = 720;
    public float updateInterval = 0.05f;
    

    void Start()
    {
        StartCoroutine(PopulateNumberField());
    }

    IEnumerator PopulateNumberField()
    {
        for (int i = 0; i < numberCount; i++)
        {
            CreateNumberAtPosition(new Vector2(Random.Range(-screenWidth, screenWidth), Random.Range(-screenHeight, screenHeight)));
            yield return new WaitForSeconds(updateInterval);
        }
    }

    void CreateNumberAtPosition(Vector2 position)
    {
        GameObject number = Instantiate(numberPrefab, transform);
        number.GetComponent<RectTransform>().anchoredPosition = position;
        number.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(0, 100).ToString();
    }
}
