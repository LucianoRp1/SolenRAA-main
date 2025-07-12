using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public Transform mapTransform;
    public float zoomSpeed = 3f; // Misma velocidad que usás en botones
    public float maxZoom = 3f;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = mapTransform.localScale;
    }

    private void Update()
    {
        DetectPinchZoom();
    }

    private void DetectPinchZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0Prev = touch0.position - touch0.deltaPosition;
            Vector2 touch1Prev = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0Prev - touch1Prev).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;

            // 🟢 Ajuste fino: igualar velocidad al botón
            Zoom(difference * (zoomSpeed * 0.03f));
        }
    }

    private void Zoom(float increment)
    {
        float currentScale = mapTransform.localScale.x;
        float newScale = Mathf.Clamp(currentScale + increment, initialScale.x, maxZoom);
        mapTransform.localScale = new Vector3(newScale, newScale, 1f);
    }

    public void ZoomIn()  => Zoom(zoomSpeed * 0.1f); // 0.3f
    public void ZoomOut() => Zoom(-zoomSpeed * 0.1f); // -0.3f
}
