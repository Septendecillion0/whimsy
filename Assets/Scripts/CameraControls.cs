using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{

    private Vector3 origin;
    private Vector3 offset;

    private Camera mainCamera;

    private bool isDragging;

    public float zoomSpeed = 10f;
    public float minFOV = 10f;
    public float maxFOV = 170f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    public void OnZoom(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float newSize = mainCamera.orthographicSize - context.ReadValue<Vector2>().y * zoomSpeed * Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Clamp(newSize, minFOV, maxFOV);

        }
    }
    public void OnDrag(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            origin = GetMousePosition();
        }
        isDragging = context.started || context.performed;

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Vampire"))
                {
                    if (hit.collider)
                    {
                        Debug.Log("Vampire clicked");
                        hit.collider.gameObject.SetActive(false);
                    }
                }

            }


        }
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
