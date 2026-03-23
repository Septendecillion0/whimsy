using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{

    private Vector3 origin;
    private Vector3 offset;

    private Camera mainCamera;

    private bool isDragging;

    public float sensitivity = 10f;
    public float minFov = 10f;
    public float maxFov = 170f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float fov = mainCamera.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        mainCamera.fieldOfView = fov;
    }


    public void OnDrag(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Drag started");
            origin = GetMousePosition();
        }
        isDragging = context.started || context.performed;

    }

    public void LateUpdate()
    {
        if (!isDragging)
        {
            return;
        }

        offset = GetMousePosition() - transform.position;
        transform.position = origin - offset;

    }

    private Vector3 GetMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

}
