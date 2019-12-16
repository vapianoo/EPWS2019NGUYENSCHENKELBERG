using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    /* variables */

    public Component routeCalculation;
    public ArrayList routeArray;

    public Vector3 distanceVector;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 endPosition_next;

    public Vector3 lookAtPosition;
    public Vector3 lookAtTarget;

    public Vector3 lookAtTarget_next;

    public int routeLength;
    public int currentStep;
    public int lookAtStep;
    public float distance;

    

    public float speed = 0.05f;

    /* allow camera to move */
    public bool moveCam = true;
    public bool moveLook = true;

    void Start()
    {
        calculate_route routeCalculation = new calculate_route();
        routeArray = routeCalculation.getRoute();

        /* set first and last position of the current part of the route */

        routeLength = routeArray.Count - 1;

        startPosition = (Vector3)routeArray[0];
        endPosition = (Vector3)routeArray[1];

        if (routeLength >= 1) {
            endPosition_next = (Vector3)routeArray[2];
            lookAtTarget_next = endPosition_next;
        }

        lookAtPosition = startPosition + (endPosition - startPosition) / 5;
        lookAtTarget = endPosition;

        /* move camera to first position of the current part of the route */
        transform.position = startPosition;

        currentStep = 1;
        lookAtStep = 1;
    }

    void Update()
    {
        /* while allowed to move, move towards the last position of the current part of the route*/

        calculateDistance(lookAtPosition, lookAtTarget);
        moveLookAtTarget(distance);

        calculateDistance(transform.position, endPosition);
        moveCamera(distance);

    }

    void calculateDistance(Vector3 start, Vector3 end)
    {
        
        distance = (end - start).magnitude;
        Debug.Log(distance);

    }

    void moveCamera(float distance)
    {
        if (moveCam && currentStep >= routeLength)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, 0.05f);
            transform.LookAt(lookAtPosition);

        } else if (moveCam && currentStep < routeLength)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition + ((endPosition_next - endPosition) / Mathf.Pow(distance,2)) / 20, speed);
            transform.LookAt(lookAtPosition);
        }

        if (distance < 1f && currentStep < routeLength)
        {
            Debug.Log("hier");
            endPosition = (Vector3)routeArray[currentStep + 1];
            currentStep++;

            if (currentStep < routeLength)
            {
                endPosition_next = (Vector3)routeArray[currentStep + 1];
            }
        }
        else if (transform.position == endPosition && currentStep >= routeLength)
        {
            Debug.Log("hier auch");
            moveCam = false;
        }
    }

    void moveLookAtTarget(float distance)
    {
        if (moveLook && lookAtStep >= routeLength)
        {
            lookAtPosition = Vector3.MoveTowards(lookAtPosition, lookAtTarget, 0.05f);
        }
        else if (moveLook && lookAtStep < routeLength)
        {
            lookAtPosition = Vector3.MoveTowards(lookAtPosition, lookAtTarget + ((lookAtTarget_next - lookAtTarget) / Mathf.Pow(distance, 2)) / 20, speed);
        }

        if (distance < 1f && lookAtStep < routeLength)
        {
            lookAtTarget = (Vector3)routeArray[lookAtStep + 1];
            lookAtStep++;

            if (lookAtStep < routeLength)
            {
                lookAtTarget_next = (Vector3)routeArray[lookAtStep + 1];
            }
        }
        else if (lookAtPosition == lookAtTarget && lookAtStep >= routeLength)
        {
            Debug.Log("hier auch");
            moveLook = false;
        }
    }
}
