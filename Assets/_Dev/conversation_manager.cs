using UnityEngine;
using UnityEngine.InputSystem;

public class conversation_manager : MonoBehaviour
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

    public void createConversation(Landmark landmark)
    {
        Debug.Log("Conversation created");
        GameObject new_conversation = Instantiate(conversation_prefab);
        new_conversation.transform.SetParent(transform, false);
        new_conversation.landmark = landmark;
        new_conversation.vampire = landmark.vampire;
        new_conversation.villager = landmark.resident;
        landmark.setConversation(new_conversation);
    }

    public void setSelectedConversation(GameObject conversation)
    {
        selected_conversation = conversation;
    }
}
