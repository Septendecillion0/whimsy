using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;


public class vampire_encounter : MonoBehaviour
{


    public GameObject target;
    public GameObject speechBubble;
    public GameObject dialogueContainer;

    public bool talking = true;
    public string conversation_state = "";
    private GameObject currentDialogueDisplay;
    private speech_bubble currentDialogueScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set target to random villager here

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialogueDisplay != null && currentDialogueScript != null)
        {
            if (currentDialogueScript.time_out == true)
            {
                Debug.Log("Dialogue timed out");
                talking = false;
                Slider slider = currentDialogueDisplay.GetComponent<Slider>();
                slider.gameObject.SetActive(false);
                currentDialogueScript = null;
                currentDialogueDisplay = null;
            }
        }

    }


    public void onSpace(InputAction.CallbackContext context)
    {
        // if (context.started)
        // {
        //     if (dialogueActive == false)
        //     {
        //         StartVampireEncounter();
        //     }
        // }

    }

    private void StartVampireEncounter()
    {

        GameObject newDialogue = Instantiate(speechBubble, dialogueContainer.transform);

        newDialogue.transform.SetParent(dialogueContainer.transform);
        speech_bubble dialogueScript = newDialogue.GetComponent<speech_bubble>();

        currentDialogueDisplay = newDialogue;
        currentDialogueScript = dialogueScript;


        Debug.Log("Dialogue started!");

    }

    public void talk(string line)
    {
        talking = true;
        StartVampireEncounter();
    }
}
