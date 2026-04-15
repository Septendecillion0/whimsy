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

    public bool conversation_started = false;
    public bool conversation_ended = false;
    public bool conversation_recorded = false;
    bool delay_cooldown = false;
    public string next_line = "";


    public List<string> vampire_history = new List<string>();
    public List<string> villager_history = new List<string>();
    public List<string> narration_history = new List<string>();

    private GameObject document;
    private Animator documentAnimator;
    public bool conversation_paused;
    //public GameObject document;

    void Awake()
    {
        //documentAnimator = documentAnimator.GetComponent<Animator>();
        ink_story = new Story(ink_json.text);
    }

    void Start()
    {
        document = GameObject.Find("/Scene/UICanvas/Document");
        documentAnimator = document.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (conversation_paused)
        {
            return;
        }

        else if (conversation_started && !delay_cooldown && !conversation_ended)
        {
            Debug.Log("Reaching InterpretDialogue from Update");
            InterpretDialogue();
        }
    }

    public void StartConversation()
    {
        Debug.Log("StartConversation was called");
        //documentAnimator.SetTrigger("DocumentDisplayed");
        conversation_started = true;
        //Debug.Log("Conversation started");
    }

    public void UpdateScore()
    {
        ScoreManager.Instance.encounter_count++;
        if (vampire.violation)
        {
            ScoreManager.Instance.total_violations++;
        }
        if (vampire.reported)
        {
            if (vampire.violation)
            {
                ScoreManager.Instance.correct_reports++;
            }
            else
            {
                ScoreManager.Instance.incorrect_reports++;
            }
        }
        if (villager == null)
        {
            ScoreManager.Instance.villagers_lost++;
        }
        if (conversation_recorded)
        {
            ScoreManager.Instance.vampires_recorded++;
        }

    }

    public void OnConversationEnd()
    {
        conversation_ended = true;
        UpdateScore();
        DayCycleManager.Instance.OnEncounterCompleted();
        SendVampireAway();
    }

    private void InterpretDialogue()
    {
        Debug.Log("Reaching InterpretDialogue");


        StartCoroutine(DialogueDelay(7.0f));
        if (ink_story.canContinue)
        {
            next_line = ink_story.Continue();
        }
        else
        {
            conversation_started = false;
        }

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
            if (!vampire.violation)
            {
                vampire.violation = true;
            }

        }

        if (tags.Contains("VAMPIRE_HUNTS"))
        {

            Debug.Log("Vampire devours the victim");
            UIManager.Instance.SendMessage("A villager has been devoured!", Color.red);
            villager = null;
            OnConversationEnd();
        }
        if (tags.Contains("VAMPIRE_LEAVES"))
        {
            OnConversationEnd();
        }

        if (tags.Contains("FAKE_WARRANT"))
        {
            UIManager.Instance.DisplayDocument();
            conversation_paused = true;
        }


    }

    public void SendVampireAway()
    {
        //Debug.Log("Vampire leaves");
        Debug.Log(vampire.gameObject.name);
        //Debug.Log(Find("Exit").name);
        vampire.GetComponent<VampirePathing>().SetNewDestination(GameObject.Find("Exit").GetComponent<Checkpoint>());
        vampire = null;
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
