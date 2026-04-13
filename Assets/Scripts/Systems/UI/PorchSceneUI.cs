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
        //Debug.Log("PorchSceneUI enabled: " + current_conversation.name);
    }

    public void ClosePorchScene()
    {
        //Debug.Log("Closing PorchSceneUI");
        GameStateManager.Instance.currentState = GameStateManager.GameState.Map;
        UIManager.Instance.HidePorchScene();
    }

    void Update()
    {

        if (current_conversation.vampire != null)
        {
            transform.Find("VampireSprite").gameObject.SetActive(true);
            transform.Find("VampireSprite").GetComponent<Image>().sprite = current_conversation.vampire.GetComponent<SpriteRenderer>().sprite;
            //transform.Find("VampireSprite").GetComponent<Image>().color = current_conversation.vampire.GetComponent<SpriteRenderer>().color;
            transform.Find("VampireSprite").transform.Find("Hat").GetComponent<Image>().color = current_conversation.vampire.gameObject.transform.Find("Hat").GetComponent<SpriteRenderer>().color;
        }
        else
        {
            transform.Find("VampireSprite").gameObject.SetActive(false);
        }

        if (current_conversation.villager != null)
        {
            transform.Find("CivilianSprite").gameObject.SetActive(true);
            transform.Find("CivilianSprite").GetComponent<Image>().sprite = current_conversation.villager.GetComponent<SpriteRenderer>().sprite;
            transform.Find("CivilianSprite").GetComponent<Image>().color = current_conversation.villager.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            transform.Find("CivilianSprite").gameObject.SetActive(false);
        }

        transform.Find("VampireDialogue").GetComponent<TextMeshProUGUI>().text = string.Join(System.Environment.NewLine, current_conversation.vampire_history);
        transform.Find("VillagerDialogue").GetComponent<TextMeshProUGUI>().text = string.Join(System.Environment.NewLine, current_conversation.villager_history);
        transform.Find("NarrationDialogue").GetComponent<TextMeshProUGUI>().text = string.Join(System.Environment.NewLine, current_conversation.narration_history);
        //transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = current_conversation.next_line;
    }

    public void OnReportButtonClicked()
    {
        ConversationManager.Instance.selected_conversation.Report();
    }

    public void OnRecordButtonClicked()
    {
        ConversationManager.Instance.selected_conversation.conversation_recorded = true;
        UIManager.Instance.SendMessage("Encounter recorded!", Color.green);
    }

    public void OnCombustButtonClicked()
    {
        ConversationManager.Instance.selected_conversation.Combust();
    }

}
