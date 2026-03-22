using UnityEngine;

public class clickable_sprite : MonoBehaviour
{


    [Tooltip("The dialogue controller")]
    public GameObject dialogue_controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseDown()
    {
        if (dialogue_controller && dialogue_controller.GetComponent<DialogueController>().dialogue_on == false)
        {
            Debug.Log("Door Clicked!");
            dialogue_controller.GetComponent<DialogueController>().playDialogue();
        }

    }
}
