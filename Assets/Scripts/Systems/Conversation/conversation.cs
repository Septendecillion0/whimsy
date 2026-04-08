using UnityEngine;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
public class Conversation : MonoBehaviour
{


    public VampireAttributes vampire;
    public GameObject villager;
    public Landmark landmark;

    public TextAsset ink_json;
    Story ink_story;

    public bool conversation_started = true;
    public bool conversation_ended = false;
    bool delay_cooldown = false;
    public string next_line = "";

    public List<string> vampire_history = new List<string>();
    public List<string> villager_history = new List<string>();
    public List<string> narration_history = new List<string>();

    void Awake()
    {
        ink_story = new Story(ink_json.text);
        if (ink_story.canContinue)
        {
            next_line = ink_story.Continue();
            InterpretDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (conversation_started && !delay_cooldown)
        {
            StartCoroutine(DialogueDelay(3.0f));
            //Debug.Log(next_line);
            if (ink_story.canContinue)
            {
                next_line = ink_story.Continue();
                InterpretDialogue();
            }
            else
            {
                conversation_started = false;
            }
        }
    }

    public void StartConversation()
    {
        conversation_started = true;
        //Debug.Log("Conversation started");
    }

    public void OnConversationEnd()
    {
        // TODO: Add logic to send vampire to next landmark
    }

    private void InterpretDialogue()
    {
        List<string> tags = ink_story.currentTags;
        if (tags.Contains("VAMPIRE"))
        {
            vampire_history.Add(next_line);
        }
        else if (tags.Contains("VILLAGER"))
        {
            villager_history.Add(next_line);
        }
        else
        {
            narration_history.Add(next_line);
        }


        if (tags.Contains("VIOLATION"))
        {
            vampire.violation = true;
        }

        if (tags.Contains("VAMPIRE_HUNTS"))
        {

            //Debug.Log("Vampire devours the victim");
            villager = null;
            SendVampireAway();
            UIManager.Instance.SendMessage("A villager has been devoured!", Color.red);
        }
        if (tags.Contains("VAMPIRE_LEAVES"))
        {
            SendVampireAway();
        }

    }

    public void SendVampireAway()
    {
        //Debug.Log("Vampire leaves");
        vampire.GetComponent<VampirePathing>().SetNewDestination(GameObject.Find("Exit").GetComponent<Checkpoint>());
        vampire = null;
        conversation_ended = true;
    }

    public void Report()
    {
        if (vampire != null && !vampire.reported)
        {
            //Debug.Log("Vampire Reported");
            vampire.reported = true;
            UIManager.Instance.SendMessage("Vampire conduct reported!");
        }
    }

    public void Combust()
    {
        if (vampire != null)
        {
            //Debug.Log("Emergency Protocol! Vampire Combusted!");
            narration_history.Add("The vampire erupts into flames!");
            conversation_started = false;
            vampire.combusted = true;
            vampire.gameObject.SetActive(false);
            vampire = null;
            UIManager.Instance.SendMessage("Vampire Vanquished!", Color.red);
            conversation_ended = true;
        }

    }

    IEnumerator DialogueDelay(float delay)
    {
        delay_cooldown = true;
        yield return new WaitForSeconds(delay);
        delay_cooldown = false;
    }
}
