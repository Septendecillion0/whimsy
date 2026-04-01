using UnityEngine;

public class GameStateManager2 : MonoBehaviour
{
    public enum GameState
    {
        Map,
        Dialogue
    }

    public GameState currentState;

    public void SetState(GameState state)
    {
        currentState = state;
    }
}
