using UnityEngine;
using UnityEngine.EventSystems;

public class NumberDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rb;
    private Vector3 offset;
    private Vector3 startPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        startPosition = transform.position;
        rb.isKinematic = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
        newPosition.z = 0;
        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rb.isKinematic = false;
        rb.velocity = Vector2.zero;
    }
}
