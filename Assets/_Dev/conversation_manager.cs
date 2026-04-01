using UnityEngine;

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

    public void OnSpace()
    {
        createConversation();
    }

    public void createConversation()
    {
        Debug.Log("Conversation created");
        GameObject new_conversation = Instantiate(conversation_prefab);
    }
}
