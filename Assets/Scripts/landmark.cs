using UnityEngine;

public class landmark : MonoBehaviour
{

    public GameObject dialogueScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void zoomIn()
    {
        dialogueScene.SetActive(true);
    }
}
