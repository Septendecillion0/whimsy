using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// manages [enemy] spawns
/// spawns [enemies] based on a time interval, with random starting, destination, and ending positions, as well as randomized attributes
/// </summary>
public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance;

    [Header("References")]
    [Header("Path")]
    public Path path;

    [Header("Checkpoint Pools")]
    public List<Checkpoint> spawnPoints;
    public List<Checkpoint> destinationPoints;
    public List<Checkpoint> exitPoints;

    [Header("Enemy Prefabs")]
    public List<GameObject> enemyPrefabs;

    //[Header("Spawn Settings")]
    //public float spawnInterval = 10f;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(SpawnLoop());
    }

    // IEnumerator SpawnLoop()
    // {
    //     while (true)
    //     {
    //         SpawnEnemy();
    //         yield return new WaitForSeconds(spawnInterval);
    //     }
    // }

    public void SpawnEnemy()
    {
        // Pick random enemy prefab
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Instantiate
        GameObject enemy = Instantiate(prefab);

        // Get components
        VampirePathing pathing = enemy.GetComponent<VampirePathing>();
        VampireAttributes attributes = enemy.GetComponent<VampireAttributes>();
        vampire_dialogue dialogue = enemy.GetComponent<vampire_dialogue>();

        enemy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        // Pick random checkpoints
        Checkpoint start = GetRandomCheckpoint(spawnPoints);
        Checkpoint destination = GetRandomCheckpoint(destinationPoints);
        RemoveDestination(destination);
        //dialogue.target = destination.resident; // set the vampire's target to the resident at their destination
        Checkpoint exit = GetRandomCheckpoint(exitPoints);

        // Assign pathing
        pathing.path = path;
        pathing.startCheckpoint = start;
        pathing.destinationCheckpoint = destination;

        // Randomly assign warrant
        attributes.validWarrant = Random.value > 0.5f;
    }

    // helper for random Checkpoint decisions
    // picks a random Checkpoint from the input list
    Checkpoint GetRandomCheckpoint(List<Checkpoint> list)
    {
        if (list.Count == 0)
        {
            return exitPoints[Random.Range(0, exitPoints.Count)];
        }
        return list[Random.Range(0, list.Count - 1)];
    }

    // 
    private void AddDestination(Checkpoint destination)
    {
        if (destinationPoints.Contains(destination)) return;
        destinationPoints.Add(destination);
    }

    private void RemoveDestination(Checkpoint destination)
    {
        if (destinationPoints.Contains(destination))
        {
            destinationPoints.Remove(destination);
        }
    }
}
