using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public BoxCollider2D sinirKutusu;

    [Header("Oda Zoom Ayarı")]
    public float targetZoom = 5f; 
    public float zoomHizi = 5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographicSize; 
    }

    void LateUpdate()
    {
        if (target == null) return;

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomHizi);

        Vector3 desiredPosition = target.position + offset;

        if (sinirKutusu != null)
        {
            Bounds b = sinirKutusu.bounds;
            float camYariBoy = cam.orthographicSize;
            float camYariEn = cam.orthographicSize * cam.aspect;

            float minX = b.min.x + camYariEn;
            float maxX = b.max.x - camYariEn;
            float minY = b.min.y + camYariBoy;
            float maxY = b.max.y - camYariBoy;

            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
