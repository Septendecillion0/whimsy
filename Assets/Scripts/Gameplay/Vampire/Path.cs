using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Path is the main class object used in enemy pathfinding
/// Path is a collection (undirected graph) of connected Checkpoint nodes 
/// Each Checkpoint's path to another Checkpoint in the Path is stored in connectionTable, accessed via FindConnection
/// </summary>
public class Path : MonoBehaviour
{
    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    // method to find the next checkpoint to move to, given the start and destination
    public Checkpoint FindConnection(Checkpoint from, Checkpoint to)
    {
        if (connectionTable.ContainsKey(from) && connectionTable[from].ContainsKey(to))
            return connectionTable[from][to];
        return null;
    }

    private void Awake()
    {
        checkpoints.Clear();
        checkpoints.AddRange(FindObjectsByType<Checkpoint>());

        BuildConnectionTable();
    }

    /// <summary>
    /// connectionTable stores "routes" from each checkpoint to another, precomputed at startup
    /// connectionTable[from][to] = next step
    /// 
    /// TODO (optional): compute in editor for debugging rather than at game startup
    /// </summary>
    private Dictionary<Checkpoint, Dictionary<Checkpoint, Checkpoint>> connectionTable
        = new Dictionary<Checkpoint, Dictionary<Checkpoint, Checkpoint>>();

    // build connectionTable via BFS
    void BuildConnectionTable()
    {
        connectionTable.Clear();

        foreach (var start in checkpoints)
        {
            var map = new Dictionary<Checkpoint, Checkpoint>();

            // BFS
            Queue<Checkpoint> queue = new Queue<Checkpoint>();
            Dictionary<Checkpoint, Checkpoint> cameFrom = new Dictionary<Checkpoint, Checkpoint>();

            queue.Enqueue(start);
            cameFrom[start] = null;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var neighbor in current.neighbors)
                {
                    if (neighbor == null) continue;

                    if (!cameFrom.ContainsKey(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            // Build next-step map
            foreach (var end in checkpoints)
            {
                if (end == start) continue;

                if (!cameFrom.ContainsKey(end))
                    continue; // unreachable

                Checkpoint current = end;

                // Walk backward until we reach start
                while (cameFrom[current] != start)
                {
                    current = cameFrom[current];
                }

                map[end] = current;
            }

            connectionTable[start] = map;
        }

        Debug.Log("Connection table built!");
    }
}
