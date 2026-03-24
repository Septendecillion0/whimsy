using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class vampire_encounter : MonoBehaviour
{


    public GameObject target;
    public GameObject speechBubble;
    public GameObject dialogueContainer;

    private bool dialogueActive = false;

    public bool talking = true;
    public string conversation_state = "";
    private speech_bubble currentDialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set target to random villager here

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialogue.time_out == true)
        {
            talking = false;
        }

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

        GameObject newDialogue = Instantiate(speechBubble, dialogueContainer.transform);

        newDialogue.transform.SetParent(dialogueContainer.transform);
        speech_bubble dialogueScript = newDialogue.GetComponent<speech_bubble>();

        currentDialogue = dialogueScript;
        dialogueActive = false;


        Debug.Log("Dialogue started!");

    }

    public void talk(string line)
    {
        talking = true;
        StartVampireEncounter();
    }
}
