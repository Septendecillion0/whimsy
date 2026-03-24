using UnityEngine;
using UnityEngine.InputSystem;

public class conversation_controller : MonoBehaviour
{

    public vampire_encounter person1;
    public vampire_encounter person2;
    public bool conversation_started = false;
    public string next_line = "Next Line";

    void Update()
    {
        if (conversation_started)
        {
            if (person1.talking == false)
            {
                person2.talk(next_line);
            }
            if (person2.talking == false)
            {
                person1.talk(next_line);
            }
        }

    }

    public void StartConversation()
    {
        person1.talk(next_line);
        conversation_started = true;
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.started && conversation_started == false)
        {
            StartConversation();
        }
    }

}
