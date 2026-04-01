using UnityEngine;
using Ink.Runtime;
using System.Collections;

public class Conversation : MonoBehaviour
{


    public VampireAttributes vampire;
    public GameObject villager;
    public Landmark landmark;

    public TextAsset ink_json;
    Story ink_story;

    public bool conversation_started = true;
    bool delay_cooldown = false;
    public string next_line = "";

    void Awake()
    {
        ink_story = new Story(ink_json.text);
        if (ink_story.canContinue)
        {
            next_line = ink_story.Continue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (conversation_started && !delay_cooldown) //&& ink_story.canContinue)
        {
            StartCoroutine(DialogueDelay(3.0f));
            Debug.Log(next_line);
            if (ink_story.canContinue)
            {
                next_line = ink_story.Continue();
            }
            else
            {
                conversation_started = false;
            }

        }
        // if (conversation_started && ink_story.canContinue)
        // {


        // }
    }

    public void StartConversation()
    {
        conversation_started = true;
        Debug.Log("Conversation started");
    }


    IEnumerator DialogueDelay(float delay)
    {
        delay_cooldown = true;
        Debug.Log("Waiting started...");
        yield return new WaitForSeconds(delay);
        Debug.Log(delay + " seconds have passed!");
        delay_cooldown = false;
    }
}
