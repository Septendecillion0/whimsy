using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        //Debug.Log("Closing PorchSceneUI");
        GameStateManager.Instance.currentState = GameStateManager.GameState.Map;
        this.gameObject.SetActive(false);
    }

    void Update()
    {

        //transform.Find("VampireSprite").GetComponent<Image>().sprite = current_conversation.vampire.GetComponent<SpriteRenderer>().sprite;
        transform.Find("VampireDialogue").GetComponent<TextMeshProUGUI>().text = string.Join(System.Environment.NewLine, current_conversation.vampire_history);
        transform.Find("VillagerDialogue").GetComponent<TextMeshProUGUI>().text = string.Join(System.Environment.NewLine, current_conversation.villager_history);
        transform.Find("NarrationDialogue").GetComponent<TextMeshProUGUI>().text = string.Join(System.Environment.NewLine, current_conversation.narration_history);
        //transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = current_conversation.next_line;
    }

}
