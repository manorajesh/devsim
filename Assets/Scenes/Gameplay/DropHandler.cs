using UnityEngine;
using TMPro;

public class SortingBoxHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        NumberDragHandler dragHandler = other.GetComponent<NumberDragHandler>();
        if (dragHandler != null && dragHandler.isBeingDragged)
        {
            TextMeshProUGUI numberText = other.GetComponentInChildren<TextMeshProUGUI>();
            if (numberText != null)
            {
                Debug.Log("Number dropped: " + numberText.text);
            }

            Destroy(other.gameObject);
        }
    }
}
