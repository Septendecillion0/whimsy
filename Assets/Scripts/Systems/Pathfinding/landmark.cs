using UnityEngine;

public class landmark : Checkpoint
{
    public GameObject resident;

    public bool eventActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartEvent()
    {
        //warningSymbol.SetActive(true);
        eventActive = true;
    }

    public void EndEvent()
    {
        //warningSymbol.SetActive(false);
        eventActive = false;
    }

    public void zoomIn()
    {
        //dialogueScene.GetComponent<porch_scene>().MakeVisible();
    }
}
