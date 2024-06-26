using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ScreenBounds : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;

    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        SetBounds();
    }

    void SetBounds()
    {
        Camera mainCamera = Camera.main;
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector2 topLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane));
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
        Vector2 bottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane));

        Vector2[] edgePoints = new Vector2[5];
        edgePoints[0] = bottomLeft;
        edgePoints[1] = topLeft;
        edgePoints[2] = topRight;
        edgePoints[3] = bottomRight;
        edgePoints[4] = bottomLeft; // Closing the loop

        edgeCollider.points = edgePoints;
    }
}
