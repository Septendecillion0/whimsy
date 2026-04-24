using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CameraControls : MonoBehaviour
{

    private Vector3 origin;
    private Vector3 offset;

    private Camera mainCamera;

    private bool isDragging;

    public float zoomSpeed = 10f;
    public float minFOV = 10f;
    public float maxFOV = 170f;

    public float minX = -20f;
    public float maxX = 20f;
    public float minY = -5f;
    public float maxY = 20f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    public void OnZoom(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject(PointerInputModule.kMouseLeftId))
        {
            return;
        }
        if (context.started)
        {
            float newSize = mainCamera.orthographicSize - context.ReadValue<Vector2>().y * zoomSpeed * Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Clamp(newSize, minFOV, maxFOV);

        }

    }
    public void OnDrag(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isDragging = false;
        }
        if (EventSystem.current.IsPointerOverGameObject(PointerInputModule.kMouseLeftId))
        {
            return;
        }
        if (context.started)
        {
            origin = GetMousePosition();
        }
        isDragging = context.started || context.performed;

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        // if (context.started)
        // {
        //     RaycastHit2D hit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        //     if (hit.collider != null)
        //     {
        //         // if (hit.collider.gameObject.CompareTag("Vampire"))
        //         // {
        //         //     if (hit.collider)
        //         //     {
        //         //         Debug.Log("Vampire clicked");
        //         //         hit.collider.gameObject.SetActive(false);
        //         //     }
        //         // }
        //         if (hit.collider.gameObject.CompareTag("Landmark"))
        //         {
        //             Debug.Log("Landmark clicked");
        //             if (hit.collider)
        //             {
        //                 Landmark landmark = hit.collider.gameObject.GetComponent<Landmark>();
        //                 if (landmark.active)
        //                 {
        //                     landmark.zoomIn();
        //                 }
        //             }
        //         }

        //     }


        // }
    }

    public void LateUpdate()
    {
        if (!isDragging)
        {
            return;
        }

        offset = GetMousePosition() - transform.position;
        transform.position = origin - offset;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);

    }

    private Vector3 GetMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

}
