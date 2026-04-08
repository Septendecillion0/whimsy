using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState
    {
        Map,
        Dialogue,
        EndOfDay
    }

    public GameState currentState;

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

    public void SetState(GameState state)
    {
        currentState = state;
    }
}
