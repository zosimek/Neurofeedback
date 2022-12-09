using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class RaceLakeController : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    float speed = 0.0f;
    float distanceTravelled;


    void Start()
    {
        // Just check if the pathCreator even exists
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<ChangeScene>().LoadScene("Main");
        }
        if (pathCreator != null)
        {
            if (PythonTest.isOverThreshold == true)
            {
                if (speed < 40)
                {
                    speed += 0.1f;
                }
            }
            else
            {
                if (speed > 0)
                {
                    speed -= 0.1f;
                    if (speed < 0) 
                    {
                        speed = 0.0f;
                    }
                }
            }

            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
