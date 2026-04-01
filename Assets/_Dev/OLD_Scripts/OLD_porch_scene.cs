using UnityEngine;
using UnityEngine.SceneManagement;

public class porch_scene : MonoBehaviour
{

    public GameObject ui;

    void Start()
    {
        toggleVisibility(false);
    }

    private void toggleVisibility(bool visible)
    {
        SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        Debug.Log("renderers: " + renderers.Length);
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = visible;
        }
        Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = visible;
        }
        ui.SetActive(visible);

    }

    public void MakeVisible()
    {
        Center();
        toggleVisibility(true);
    }

    public void Center()
    {
        // Define the center of the viewport
        Vector3 viewportCenter = new Vector3(0.5f, 0.5f, 0f); // X and Y are 0.5 for center, Z is 0 for 2D

        // Convert the viewport coordinates to world space coordinates
        Vector3 worldCenterPoint = Camera.main.ViewportToWorldPoint(viewportCenter);

        transform.position = worldCenterPoint;
        transform.position = new Vector3(transform.position.x, transform.position.y, 5);
    }

    public void OnReturnButton()
    {
        toggleVisibility(false);
    }

    public void OnReportButton()
    {
        Debug.Log("VAMPIRE REPORTED");
    }
}
