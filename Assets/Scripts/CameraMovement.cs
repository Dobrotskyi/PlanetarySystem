using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _zoomMin = 0.1f;
    [SerializeField] private float _zoomMax = 100f;
    private Vector3 _mouseWorldPosStart;
    private float _zoomScale = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
            _mouseWorldPosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(2))
            Pan();

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void Pan()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Vector3 mouseWorldPosDiff = _mouseWorldPosStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += mouseWorldPosDiff;
        }
    }

    private void Zoom(float zoomDiff)
    {
        if (zoomDiff != 0)
        {
            _mouseWorldPosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomDiff * _zoomScale, _zoomMin, _zoomMax);
            Vector3 mouseWorldPosDiff = _mouseWorldPosStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += mouseWorldPosDiff;
        }
    }
}
