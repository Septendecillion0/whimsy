using UnityEngine;
using UnityEngine.InputSystem;

public class ConversationManager : MonoBehaviour
{
    public static ConversationManager Instance;
    public GameObject conversation_prefab;
    public GameObject selected_conversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate managers
        }
    }

    public void CreateConversation(Landmark landmark)
    {
        Debug.Log("Conversation created");
        GameObject new_conversation_prefab = Instantiate(conversation_prefab);
        Conversation new_conversation = new_conversation_prefab.GetComponent<Conversation>();
        new_conversation.transform.SetParent(transform, false);
        new_conversation.landmark = landmark;
        new_conversation.vampire = landmark.vampire;
        new_conversation.villager = landmark.resident;
        landmark.SetConversation(new_conversation);
    }

    public void TEST_CreateConversationInTestScene()
    {
        Debug.Log("Conversation created");
        GameObject new_conversation_prefab = Instantiate(conversation_prefab);
        Conversation new_conversation = new_conversation_prefab.GetComponent<Conversation>();
        new_conversation.transform.SetParent(transform, false);
        selected_conversation = new_conversation_prefab;
    }

    public GameObject GetSelectedConversation()
    {
        return selected_conversation;
    }
    public void SetSelectedConversation(GameObject conversation)
    {
        selected_conversation = conversation;
    }

}
