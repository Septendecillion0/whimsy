using UnityEngine;
using UnityEngine.InputSystem;

public class ConversationManager : MonoBehaviour
{

    public GameObject conversation_prefab;
    public GameObject selected_conversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            createConversation();
        }
    }

    public void CreateConversation(Landmark landmark)
    {
        Debug.Log("Conversation created");
        Conversation new_conversation = Instantiate(conversation_prefab);
        new_conversation.transform.SetParent(transform, false);
        new_conversation.landmark = landmark;
        new_conversation.vampire = landmark.vampire;
        new_conversation.villager = landmark.resident;
        landmark.SetConversation(new_conversation);
    }

    public void SetSelectedConversation(GameObject conversation)
    {
        selected_conversation = conversation;
    }
}
