using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());
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
    }

    // Returns the wanted rotation of the enemy based on start & end waypoints
    private float HandleRotation(Vector3 start, Vector3 end)
    {
        int xDelta = Mathf.RoundToInt(end.x - start.x);
        int yDelta = Mathf.RoundToInt(end.y - start.y);

        // RIGHT
        if (xDelta >= 1 && yDelta == 0)
        {
            return 90f;
        }
        // LEFT
        else if (xDelta <= -1 && yDelta == 0)
        {
            return -90f;
        } 
        // UP
        else if (xDelta == 0 && yDelta >= 1)
        {
            return 0f;
        } 
        // DOWN
        else
        {
            return 180f;
        }
    }
}
