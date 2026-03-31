using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Subclass object of 'Path' Class object
/// A Checkpoint is a node of the Path tree, which is used for enemy(vampire) pathfinding through the map
/// only holds information about its location and neighbors
/// </summary>
/// 
public class Checkpoint : MonoBehaviour
{

    public GameObject landmarkScene;
    public List<Checkpoint> neighbors = new List<Checkpoint>();
    // Use OnValidate to automatically create the backwards-facing connection when adding connections
    // note: does not automatically remove backwards-facing connections when removing
    private void OnValidate()
    {
        // Ensure bidirectional connections
        foreach (var neighbor in neighbors)
        {
            if (neighbor == null) continue;

            if (!neighbor.neighbors.Contains(this))
            {
                neighbor.neighbors.Add(this);
            }
        }
    }
    // Using Gizmos to draw editor elements
    private void OnDrawGizmos()
    {
        // Draw the node
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.2f);

        // Draw connections
        Gizmos.color = Color.green;
        foreach (var neighbor in neighbors)
        {
            if (neighbor != null)
            {
                Gizmos.DrawLine(transform.position, neighbor.transform.position);
            }
        }
    }
}
