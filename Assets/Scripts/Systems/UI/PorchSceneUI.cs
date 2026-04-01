using UnityEngine;
using TMPro;

public class PorchSceneUI : MonoBehaviour
{
    private Conversation current_conversation;

    void OnEnable()
    {
        current_conversation = ConversationManager.Instance.selected_conversation.GetComponent<Conversation>();
    }

    void Update()
    {
        transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = current_conversation.next_line;
    }

}
