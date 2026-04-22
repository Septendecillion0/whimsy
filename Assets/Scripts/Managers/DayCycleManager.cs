using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DayCycleManager : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI timeDisplay;
    public float remainingTime = 90f;
    private bool day_ended = false;

    public static DayCycleManager Instance;
    private int total_daily_encounters = 0;
    public float spawnInterval = 10f;
    private int encounters_started = 0;
    private int encounters_completed = 0;



    void Start()
    {
        total_daily_encounters = LevelManager.Instance.levelData.level_conversations.Length;
        StartCoroutine(SpawnEncounterLoop());
    }

    void Update()
    {
        if (!day_ended)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }

            else if (remainingTime <= 0)
            {
                day_ended = true;
                StartCoroutine(EndDay());
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timeDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }




    }

    public void OnEncounterCompleted()
    {
        encounters_completed++;
        if (encounters_completed == total_daily_encounters)
        {
            StartCoroutine(EndDay());
        }
    }

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

    IEnumerator SpawnEncounterLoop()
    {
        while (encounters_started < total_daily_encounters && GameStateManager.Instance.currentState != GameStateManager.GameState.EndOfDay)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnManager.Instance.SpawnEnemy();
            encounters_started++;
        }
        Debug.Log("All encounters spawned");
    }

    IEnumerator EndDay()
    {
        Debug.Log("End of Day triggered");
        //yield return new WaitForSeconds(5f);
        Debug.Log("Day ended");
        UIManager.Instance.ShowEndOfDayReport();
        GameStateManager.Instance.SetState(GameStateManager.GameState.EndOfDay);
        yield return null;
    }
}
