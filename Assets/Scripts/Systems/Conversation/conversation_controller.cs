using UnityEngine;
using UnityEngine.InputSystem;
using Ink.Runtime;
using System.Collections.Generic;

public class conversation_controller : MonoBehaviour
{

    public vampire_dialogue person1;
    public vampire_dialogue person2;
    public bool conversation_started = false;
    public vampire_dialogue current_speaker = null;
    public string next_line = "";
    public string introKnot = "";
    public TextAsset ink_json;
    Story ink_story;


    void Awake()
    {
        ink_story = new Story(ink_json.text);
        if (ink_story.canContinue)
        {
            next_line = ink_story.Continue();
        }
    }

    public void set_speakers(GameObject speaker1, GameObject speaker2)
    {
        person1 = speaker1.GetComponent<vampire_dialogue>();
        person2 = speaker2.GetComponent<vampire_dialogue>();
    }

    void Update()
    {
        if (conversation_started && ink_story.canContinue)
        {

            next_line = ink_story.Continue();
            List<string> tags = ink_story.currentTags;

            if (current_speaker.talking == false)
            {
                if (tags.Contains("VAMPIRE"))
                {
                    current_speaker = person1;
                    current_speaker.talk(next_line);
                }
                if (tags.Contains("VILLAGER"))
                {
                    current_speaker = person2;
                    current_speaker.talk(next_line);
                }
            }

            else
            {
                Debug.Log(current_speaker.ToString() + "is talking.");
            }



            // if (current_speaker == person1)
            // {
            //     if (person1.talking == true)
            //     {
            //         Debug.Log("Person 1 is talking");
            //     }
            //     else
            //     {
            //         current_speaker = person2;
            //         if (ink_story.canContinue)
            //         {
            //             next_line = ink_story.Continue();
            //         }
            //         person2.talk(next_line);
            //     }
            // }
            // else if (current_speaker == person2)
            // {
            //     if (person2.talking == true)
            //     {
            //         Debug.Log("Person 2 is talking");
            //     }
            //     else
            //     {
            //         current_speaker = person1;
            //         if (ink_story.canContinue)
            //         {
            //             next_line = ink_story.Continue();
            //         }
            //         person1.talk(next_line);
            //     }
            // }
        }

    }

    public void StartConversation(string id = "")
    {
        if (id == "")
        {
            id = introKnot;
        }

        ink_story.ChoosePathString(id);

        if (ink_story.canContinue)
        {
            next_line = ink_story.Continue();
            List<string> tags = ink_story.currentTags;
            if (tags.Contains("VAMPIRE"))
            {
                current_speaker = person1;
            }
            if (tags.Contains("VILLAGER"))
            {
                current_speaker = person2;
            }
            current_speaker.talk(next_line);
            conversation_started = true;
        }

    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.started && conversation_started == false)
        {
            Debug.Log("Starting conversation");
            if (introKnot != "")
            {
                Debug.Log(introKnot);
                StartConversation(introKnot);
            }

        }
    }

}
