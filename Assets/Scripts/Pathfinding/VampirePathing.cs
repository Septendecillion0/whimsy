using UnityEngine;
using System;
/// <summary>
/// VampirePathing controls the position/movement of a vampire
/// given a Path, start Checkpoint, and destination Checkpoint, it will immediately start moving from the start to the destination
/// reaching the destination triggers [insert event here]
/// </summary>


/// TODO:
/// - add slight variation (randomize) in pathing
/// - add midpoints (do more around the map)
/// - add dynamic behavior (respond to player input or other events)
public class VampirePathing : MonoBehaviour
{
    public Path path;
    public Checkpoint startCheckpoint;
    public Checkpoint destinationCheckpoint;


    public float speed = 3f;
    public float arriveDistance = 0.05f; // buffer distance between vampire and destination

    public Action<VampirePathing> OnDestinationReached; // event to be called when destination is reached

    private Checkpoint currentCheckpoint;
    private Checkpoint targetCheckpoint;

    private bool reachedDestination = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (path == null || startCheckpoint == null || destinationCheckpoint == null)
        {
            Debug.LogError("VampirePathing is missing references!");
            enabled = false;
            return;
        }

        // Move to starting position
        currentCheckpoint = startCheckpoint;
        transform.position = currentCheckpoint.transform.position;

        // Get first step
        targetCheckpoint = path.FindConnection(currentCheckpoint, destinationCheckpoint);

        if (targetCheckpoint == null)
        {
            Debug.LogError("No path found to destination!");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedDestination || targetCheckpoint == null)
            return;

        MoveToTarget();
    }

    void MoveToTarget()
    {
        Vector3 targetPos = targetCheckpoint.transform.position;

        Vector3 direction = (targetPos - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, targetPos);

        if (distance <= arriveDistance)
        {
            ArriveAtCheckpoint();
        }
    }

    void ArriveAtCheckpoint()
    {
        currentCheckpoint = targetCheckpoint;

        if (currentCheckpoint == destinationCheckpoint)
        {
            reachedDestination = true;
            OnReachedDestination();
            return;
        }

        targetCheckpoint = path.FindConnection(currentCheckpoint, destinationCheckpoint);

        if (targetCheckpoint == null)
        {
            Debug.LogError("Path broke mid-navigation!");
            reachedDestination = true;
        }
    }

    void OnReachedDestination()
    {
        //Debug.Log($"{gameObject.name} reached destination!");

        OnDestinationReached?.Invoke(this);
        currentCheckpoint.landmarkScene.GetComponent<landmark>().StartEvent();
    }

    public void SetNewDestination(Checkpoint newDestination)
    {
        if (newDestination == null)
        {
            Debug.LogError("New destination is null!");
            return;
        }

        destinationCheckpoint = newDestination;
        reachedDestination = false;


        targetCheckpoint = path.FindConnection(currentCheckpoint, destinationCheckpoint);

        if (targetCheckpoint == null)
        {
            Debug.LogError("No path to new destination!");
            reachedDestination = true;
        }


    }
}