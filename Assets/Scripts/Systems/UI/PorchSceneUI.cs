using UnityEngine;
using TMPro;

public class PorchSceneUI : MonoBehaviour
{
    public static PorchSceneUI Instance;
    private Conversation current_conversation;

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

    void OnEnable()
    {

        current_conversation = ConversationManager.Instance.selected_conversation.GetComponent<Conversation>();
        Debug.Log("PorchSceneUI enabled: " + current_conversation.name);
    }

    public void ClosePorchScene()
    {
        Debug.Log("Closing PorchSceneUI");
        GameStateManager.Instance.currentState = GameStateManager.GameState.Map;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = current_conversation.next_line;
    }

}
