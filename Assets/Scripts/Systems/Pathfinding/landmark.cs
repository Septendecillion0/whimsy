using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
/// <summary>
/// Landmark is a subclass of Checkpoint
/// represents a house/car/location where interactions and encounters will take place (rather than just a pathing node)
/// Takes resident and vampire as input and gives it to ConversationManager to 
/// </summary>
public class Landmark : Checkpoint, IPointerClickHandler
{
    [Header("Data")]
    // TODO: replace with Resident monobehavior once implemented
    public GameObject resident;
    public VampireAttributes vampire;
    public enum LandmarkType
    {
        House,
        Car,
        Street
    }

    private bool active;
    private Collider2D encounterButton;
    private ConversationManager conversationManager;
    private Conversation conversation;
    private void Awake()
    {
        //conversationManager = ConversationManager.Instance;

        encounterButton = GetComponent<Collider2D>();
        if (encounterButton == null)
            Debug.LogWarning("Landmark requires a Collider2D to be clickable!");
    }

    private void Update()
    {
        if ((!active) || (GameStateManager.Instance.currentState != GameStateManager.GameState.Map)) return;

        // Detect left mouse button
        // if (Input.GetMouseButtonDown(0))
        // {
        //     // Convert mouse position to world point
        //     Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //     // Check if the click overlaps the landmark collider
        //     if (encounterButton.OverlapPoint(mousePos))
        //     {
        //         OnLandmarkClicked();
        //     }
        // }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name + " was clicked!");
        if ((!active) || (GameStateManager.Instance.currentState != GameStateManager.GameState.Map)) return;

        //Debug.Log("Landmark clicked and active");
        OnLandmarkClicked();
    }

    public void OnLandmarkClicked()
    {
        GameStateManager.Instance.SetState(GameStateManager.GameState.Dialogue);
        ConversationManager.Instance.SetSelectedConversation(conversation);
        UIManager.Instance.ShowPorchScene();
    }

    // Called by ConversationManager when a conversation is created
    // allows the landmark to be clicked on
    public void SetConversation(Conversation new_conversation)
    {
        active = true;
        conversation = new_conversation;
        transform.Find("EventWarningSign").gameObject.SetActive(true);
    }
}
