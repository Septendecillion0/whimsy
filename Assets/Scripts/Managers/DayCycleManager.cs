using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DayCycleManager : MonoBehaviour
{

    public static DayCycleManager Instance;

    public int total_daily_encounters = 0;
    public float spawnInterval = 10f;
    private int encounters_started = 0;
    private int encounters_completed = 0;


    void Start()
    {
        StartCoroutine(SpawnEncounterLoop());
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
        while (encounters_started < total_daily_encounters)
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
        yield return new WaitForSeconds(5f);
        Debug.Log("Day ended");
        UIManager.Instance.ShowEndOfDayReport();
        GameStateManager.Instance.SetState(GameStateManager.GameState.EndOfDay);
    }
}
