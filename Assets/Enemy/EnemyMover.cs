using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Waypoint> path = new List<Waypoint>();


    private void OnEnable()
    {
        FindPath();
        ReturnEnemyToStart();
        StartCoroutine(FollowPath());
    }

    // Finds the path according to the path tags
    private void FindPath()
    {
        path.Clear();
        // Find the parent of the tiles that cointain the path
        // The path has to be sorted in hierarchy
        GameObject waypoints = GameObject.FindGameObjectWithTag("Path");
        // Assign the waypoints to our path list
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            path.Add(waypoints.transform.GetChild(i).GetComponent<Waypoint>());
        }
    }

    // Returns / places the enemy to start position of the path
    private void ReturnEnemyToStart()
    {
        this.transform.position = path[0].transform.position;
    }

    // Prints all waypoints name for this enemy - COROUTINE
    IEnumerator FollowPath()
    {
        foreach (Waypoint w in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = w.transform.position;
            float travelPercent = 0f;

            // Move progress
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                // LERP the start & beginning vectors to return the new position
                Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, travelPercent);

                // Call the Handle Rotation method to return
                //Quaternion newRotation = Quaternion.Euler(0f, HandleRotation(startPosition, endPosition), 0f);
                transform.LookAt(endPosition);

                // Sets the final enemy position
                this.transform.position = newPosition;
                //this.transform.SetPositionAndRotation(newPosition, newRotation);

                // Update each frame
                yield return new WaitForEndOfFrame();
            }
        }
        // End of path reached
        EnemyEndOfPathReached();
    }

    private void EnemyEndOfPathReached()
    {
        // (Destroy) deactivate the enemy
        GetRidOfEnemy();
        // Damage the player

        // TODO: screen shake
    }

    private void GetRidOfEnemy()
    {
        // Enemy destruction, particles, sound effects etc.
        this.gameObject.SetActive(false);
    }

}
