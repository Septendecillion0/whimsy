using UnityEngine;
using UnityEngine.SceneManagement;

public class porch_scene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnReturnButton()
    {
        gameObject.SetActive(false);
    }

    public void OnReportButton()
    {
        Debug.Log("VAMPIRE REPORTED");
    }
}
