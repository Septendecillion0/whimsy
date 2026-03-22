using Ink.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
public class DialogueController : MonoBehaviour
{

    // Set this file to your compiled json asset
    [SerializeField]
    private TextAsset inkJSONAsset = null;

    [Tooltip("The text field for the interaction")]
    public TMP_Text text_label;

    [Tooltip("The dialogue panel")]
    public GameObject text_panel;

    [Tooltip("The choices container")]
    public Transform choices_container;

    [Tooltip("A button prefab for the choices")]
    [SerializeField]
    private Button button_prefab = null;

    // The ink story that we're wrapping
    Story _inkStory;
    public bool dialogue_on = false;

    // keep track of the state of the dialogue with an int variable
    private int dialogue_state = 0;
    //the state variable can have different values that I make human-readable with constants 
    private int DIALOGUE_OFF = 0; //no dialogue
    private int WAIT_CONFIRM = 1; //line has been typed wait to advance
    private int WAIT_CHOICE = 2; //the next step will be to display the choices without advancing the story
    private int CHOICE_DISPLAYED = 3; //choices are displayed wait for player choice

    void Awake()
    {
        // inkAsset = Resources.Load<TextAsset>("Dialogue");
        Debug.Log("Awake");


        LoadDialogues();
        text_label.text = "";

        text_panel.SetActive(false);
        choices_container.gameObject.SetActive(false);

        //playDialogue();

    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null && keyboard.spaceKey.wasPressedThisFrame)
        {


            // Debug.Log("NEW INPUT SYSTEM, space key pressed");
            // Debug.Log("Can continue: " + _inkStory.canContinue);
            // Debug.Log(_inkStory.currentText);
            // Debug.Log("dialogue state: " + dialogue_state);
            // for (int i = 0; i < _inkStory.currentChoices.Count; i++)
            // {
            //     Debug.Log("Choice " + (i + 1) + ". " + _inkStory.currentChoices[i].text);
            // }

            if (dialogue_state != CHOICE_DISPLAYED)
            {
                continueDialogue();
            }




            // if (_inkStory.canContinue && dialogue_state != CHOICE_DISPLAYED && dialogue_state != DIALOGUE_OFF)
            // {
            //     continueDialogue();
            // }

        }
    }

    void LoadDialogues()
    {
        _inkStory = new Story(inkJSONAsset.text);
    }

    public void playDialogue()
    {

        if (_inkStory.canContinue && dialogue_state != DIALOGUE_OFF && dialogue_state != CHOICE_DISPLAYED)
        {
            continueDialogue();
        }
        else if (dialogue_state == DIALOGUE_OFF)
        {
            dialogue_on = true;

            // I think this will allow us to change where the dialoge starts...
            //story.ChoosePathString(id);

            text_panel.SetActive(true);
            continueDialogue();
        }

        // while (_inkStory.canContinue)
        // {
        //     text_label.text = _inkStory.Continue();
        // }

        // if( _inkStory.currentChoices.Count > 0 )
        // {
        //     for (int i = 0; i < _inkStory.currentChoices.Count; ++i) {
        //         Choice choice = _inkStory.currentChoices [i];
        //         Debug.Log("Choice " + (i + 1) + ". " + choice.text);
        //     }
        // }

        // //...and when the player provides input:

        //     _inkStory.ChooseChoiceIndex (index);

        // //And now you're ready to return to step 1, and present content again.

    }

    void continueDialogue()
    {
        RemoveChoices();

        if (dialogue_state == WAIT_CHOICE)
        {
            DisplayChoices();
        }
        else if (_inkStory.canContinue || _inkStory.currentChoices.Count > 0)
        {


            _inkStory.Continue();

            if (_inkStory.currentText != "")
            {
                DisplayLine(_inkStory.currentText);
            }

            if (_inkStory.currentChoices.Count > 0 && _inkStory.currentText != "")
            {
                dialogue_state = WAIT_CHOICE;
            }

            if (!_inkStory.canContinue && _inkStory.currentChoices.Count == 0)
            {
                EndDialogue();
            }

        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        text_label.text = "";
        text_panel.SetActive(false);
        choices_container.gameObject.SetActive(false);
        dialogue_on = false;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _inkStory.ChooseChoiceIndex(choice.index);
        //Debug.Log("Choosing choice " + choice.index);
        //Debug.Log("Choice " + choice.index + ". " + choice.text);
        dialogue_state = WAIT_CONFIRM;
        continueDialogue();
    }

    void DisplayLine(string txt)
    {
        text_label.text = txt.Trim();
    }

    void DisplayChoices()
    {

        Debug.Log("Displaying choices");
        //clear selected ui element (unity UI quirk)
        //EventSystem.current.SetSelectedGameObject(null);

        dialogue_state = CHOICE_DISPLAYED;

        choices_container.gameObject.SetActive(true);

        if (_inkStory.currentChoices.Count > 0)
        {


            for (int i = 0; i < _inkStory.currentChoices.Count; i++)
            {

                Debug.Log("Creating Button");
                Choice choice = _inkStory.currentChoices[i];
                Button button = CreateChoice(choice.text.Trim());

                Debug.Log("Adding listener");
                button.onClick.AddListener(() => OnClickChoiceButton(choice));

                // Tell the button what to do when we press it
                // button.onClick.AddListener(delegate
                // {
                //     //OnClickChoiceButton(choice);
                //     Debug.Log("Button clicked");
                // });

                //select the first button
                // if (i == 0)
                // {
                //     EventSystem.current.firstSelectedGameObject = button.gameObject;
                //     EventSystem.current.SetSelectedGameObject(button.gameObject);
                // }
            }

            LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
        }
    }

    Button CreateChoice(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(button_prefab) as Button;
        choice.transform.SetParent(choices_container, false);

        // Gets the text from the button prefab
        TMP_Text choice_text = choice.GetComponentInChildren<TMP_Text>();
        choice_text.text = text;

        return choice;
    }

    void RemoveChoices()
    {
        int childCount = choices_container.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(choices_container.GetChild(i).gameObject);
        }

        choices_container.gameObject.SetActive(false);
    }


    public void onButtonClick()
    {
        Debug.Log("CLICKED");
        continueDialogue();
    }

}




