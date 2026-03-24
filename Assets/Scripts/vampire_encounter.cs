using UnityEngine;
using UnityEngine.InputSystem;

public class vampire_encounter : MonoBehaviour
{


    public GameObject target;
    public GameObject dialogueBox;
    public GameObject dialogueContainer;

    private bool dialogueActive = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set target to random villager here

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onSpace(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (dialogueActive == false)
            {
                StartVampireEncounter();
            }
        }

    }
    private void StartVampireEncounter()
    {
        dialogueActive = true;

        GameObject newDialogue = Instantiate(dialogueBox, dialogueContainer.transform);
        //newDialogue.text = "Hello, I am the vampire. What do you want?";
        newDialogue.transform.SetParent(dialogueContainer.transform);

        dialogueActive = false;


        Debug.Log("Dialogue started!");

    }
}
