using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    /* variables */

    public Component routeCalculation;
    public ArrayList routeArray;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 lastPosition;
    public Vector3 endPosition_next;
    public Vector3 interpolatedTarget;

    public int routeLength;
    public int currentStep;
    public float distance;

    public float speed = 0.1f;

    /* allow camera to move */
    public bool moveCam = true;

    void Start()
    {
        calculate_route routeCalculation = new calculate_route();
        routeArray = routeCalculation.getRoute();

        /* set first and last position of the current part of the route */

        routeLength = routeArray.Count - 1;

        startPosition = (Vector3)routeArray[0];
        endPosition = (Vector3)routeArray[1];

        if (routeLength >= 1)
        {
            endPosition_next = (Vector3)routeArray[2];
        }

        /* move camera to first position of the current part of the route */
        transform.position = startPosition;

        currentStep = 1;
    }

    void Update()
    {
        /* while allowed to move, move towards the last position of the current part of the route*/

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
        interpolateTarget();

        if (moveCam && currentStep >= routeLength)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, 0.05f);
            transform.LookAt(endPosition);

        }
        else if (moveCam && currentStep < routeLength)
        {
            transform.position = Vector3.MoveTowards(transform.position, interpolatedTarget, 0.05f);
            transform.LookAt(interpolatedTarget);
        }

        if (distance < .4f && currentStep < routeLength)
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

    void interpolateTarget()
    {
        interpolatedTarget = endPosition + ((endPosition_next - endPosition) / Mathf.Pow(distance, 2)) / 20;
    }
}
