using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// manages [enemy] spawns
/// spawns [enemies] based on a time interval, with random starting, destination, and ending positions, as well as randomized attributes
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    [Header("Path")]
    public Path path;

    [Header("Checkpoint Pools")]
    public List<Checkpoint> spawnPoints;
    public List<Checkpoint> destinationPoints;
    public List<Checkpoint> exitPoints;

    [Header("Enemy Prefabs")]
    public List<GameObject> enemyPrefabs;

    [Header("Spawn Settings")]
    public float spawnInterval = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogError("No enemy prefabs assigned!");
            return;
        }

        // Pick random enemy prefab
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Instantiate
        GameObject enemy = Instantiate(prefab);

        // Get components
        VampirePathing pathing = enemy.GetComponent<VampirePathing>();
        VampireAttributes attributes = enemy.GetComponent<VampireAttributes>();
        vampire_dialogue dialogue = enemy.GetComponent<vampire_dialogue>();
        DELETEpathingtestscript testScript = enemy.GetComponent<DELETEpathingtestscript>();

        if (pathing == null || attributes == null)
        {
            Debug.LogError("Enemy prefab missing required components!");
            return;
        }

        // Pick random checkpoints
        Checkpoint start = GetRandomCheckpoint(spawnPoints);
        Checkpoint destination = GetRandomCheckpoint(destinationPoints);
        destinationPoints.Remove(destination);
        dialogue.target = destination.resident; // set the vampire's target to the resident at their destination
        Checkpoint exit = GetRandomCheckpoint(exitPoints);



        // Assign pathing
        pathing.path = path;
        pathing.startCheckpoint = start;
        pathing.destinationCheckpoint = destination;

        // Assign next destination (for after first stop)
        if (testScript != null)
        {
            testScript.nextDestination = exit;
        }

        // Randomly assign warrant
        attributes.validWarrant = Random.value > 0.5f;

        Debug.Log($"Spawned {enemy.name} | Cool: {attributes.validWarrant}");
    }

    // helper for random Checkpoint decisions
    // picks a random Checkpoint from the input list
    Checkpoint GetRandomCheckpoint(List<Checkpoint> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("Checkpoint list is empty!");
            return null;
        }

        return list[Random.Range(0, list.Count)];
    }
}
