using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    void Start()
    {
        PrintWaypointsName();
    }

    // Prints all waypoints name for this enemy.
    private void PrintWaypointsName()
    {
        foreach (Waypoint w in path)
        {
            Debug.Log(w.name);
        }
    }
}
