using UnityEngine;

public class GameStateManager
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
