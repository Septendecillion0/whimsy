using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;
    private bool isLoading = false;

    // current scene number
    [SerializeField] private int currentLevelIndex;

    [SerializeField] public LevelData levelData;
    public int conversation_count = 0;



    // Temporary variables for keeping "score" across multiple days.
    // TODO: rework or remove score manager to keep scoring in one place
    // public int encounter_count = 0;
    // public int total_violations = 0;
    // public int correct_reports = 0;
    // public int incorrect_reports = 0;
    // public int vampires_recorded = 0;
    // public int villagers_lost = 0;


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

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Loads the next day and adds the score from the previous day
    /// 
    /// TODO: add protection to reload same scene if it is the last scene in the index
    /// </summary>
    public void NextDay()
    {
        if (isLoading) return;

        //TOD
        StartCoroutine(LoadScene(currentLevelIndex + 1));
    }

    /// <summary>
    /// Reloads the current day and discards temporary score changes
    /// </summary>

    public void RestartDay()
    {
        if (isLoading) return;
        StartCoroutine(LoadScene(currentLevelIndex));
    }

    /// <summary>
    /// Loads the scene given by index
    /// </summary>
    private IEnumerator LoadScene(int index)
    {
        isLoading = true;

        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        op.allowSceneActivation = false;

        while (op.progress < 0.9f)
        {
            // await Task.Yield();
            // ^placeholder cleanup task routine
            yield return null; // wait a frame
        }

        op.allowSceneActivation = true;

        isLoading = false;
    }

    // Used to fetch sequential conversations as set in Level Data for scripted version (will grab next knot in sequence)
    public string GetNextConversation()
    {
        return levelData.level_conversations[conversation_count];
        conversation_count++;
    }

    // Used to fetch random conversations for non-scripted version (will grab random knot from Level Data)
    public string GetRandomConversation()
    {
        return levelData.level_conversations[Random.Range(0, levelData.level_conversations.Length - 1)];
    }

}
