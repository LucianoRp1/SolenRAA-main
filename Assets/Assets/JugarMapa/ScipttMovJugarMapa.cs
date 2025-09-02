using UnityEngine;

public class MapMovementUI : MonoBehaviour
{
    public RectTransform mapRect;
    public RectTransform canvasRect;
    public float dragSensitivity = 0.5f; // Sensibilidad de arrastre
    public float smoothTime = 0.1f;      // Suavizado del movimiento
    public float inertiaDecay = 5f;      // Qué tan rápido se frena la inercia

    private Vector2 dragOrigin;
    private Vector2 velocity;    // Velocidad actual
    private Vector2 targetPos;   // Posición hacia la que queremos ir
    private bool dragging;

    void Update()
    {
        // --- MOUSE ---
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            dragOrigin = Input.mousePosition;
            velocity = Vector2.zero; // Reset inercia
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging && Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)Input.mousePosition - dragOrigin;
            dragOrigin = Input.mousePosition;

            targetPos = mapRect.anchoredPosition + delta * dragSensitivity;
            ClampTargetPosition();
        }
        else
        {
            // Aplicar inercia cuando no arrastramos
            if (velocity.magnitude > 0.01f)
            {
                targetPos += velocity * Time.deltaTime;
                ClampTargetPosition();
                velocity = Vector2.Lerp(velocity, Vector2.zero, inertiaDecay * Time.deltaTime);
            }
        }

        // Movimiento suavizado
        mapRect.anchoredPosition = Vector2.Lerp(mapRect.anchoredPosition, targetPos, smoothTime * 10f);

        // Calcular velocidad para inercia
        if (dragging)
        {
            velocity = (targetPos - mapRect.anchoredPosition) / Time.deltaTime;
        }
    }

    private void ClampTargetPosition()
    {
        float limitX = (mapRect.rect.width - canvasRect.rect.width) / 2f;
        float limitY = (mapRect.rect.height - canvasRect.rect.height) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -limitX, limitX);
        targetPos.y = Mathf.Clamp(targetPos.y, -limitY, limitY);
    }
}
