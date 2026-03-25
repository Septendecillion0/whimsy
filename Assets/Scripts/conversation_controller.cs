using UnityEngine;
using UnityEngine.InputSystem;

public class conversation_controller : MonoBehaviour
{

    public vampire_encounter person1;
    public vampire_encounter person2;
    public bool conversation_started = false;
    public vampire_encounter current_speaker = null;
    public string next_line = "Next Line";


    void Update()
    {
        if (conversation_started)
        {
            if (current_speaker == person1)
            {
                if (person1.talking == true)
                {
                    Debug.Log("Person 1 is talking");
                }
                else
                {
                    current_speaker = person2;
                    person2.talk(next_line);
                }
            }
            else if (current_speaker == person2)
            {
                if (person2.talking == true)
                {
                    Debug.Log("Person 2 is talking");
                }
                else
                {
                    current_speaker = person1;
                    person1.talk(next_line);
                }
            }
        }

    }

    public void StartConversation()
    {
        current_speaker = person1;
        person1.talk(next_line);
        conversation_started = true;
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.started && conversation_started == false)
        {
            Debug.Log("Starting conversation");
            StartConversation();
        }
    }

}
