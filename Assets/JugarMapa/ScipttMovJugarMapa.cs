using UnityEngine;

public class MapMovementUI : MonoBehaviour
{
    public RectTransform mapRect;      // La imagen del mapa
    public RectTransform canvasRect;   // El área visible (pantalla)
    public float dragSpeed = 0.5f;     // Velocidad ajustable (reducida)

    private Vector2 dragOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector2 delta = (Vector2)Input.mousePosition - dragOrigin;
        dragOrigin = Input.mousePosition;

        Vector2 newPos = mapRect.anchoredPosition + delta * dragSpeed;

        float limitX = (mapRect.rect.width - canvasRect.rect.width) / 2f;
        float limitY = (mapRect.rect.height - canvasRect.rect.height) / 2f;

        newPos.x = Mathf.Clamp(newPos.x, -limitX, limitX);
        newPos.y = Mathf.Clamp(newPos.y, -limitY, limitY);

        mapRect.anchoredPosition = newPos;
    }
}
