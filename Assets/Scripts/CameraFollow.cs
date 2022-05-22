using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Position of what we want to look at.
    public Transform lookAt;
    // Box with.x bound.
    public float boundX = 0.2f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // The difference between camera position and the position of what we look at.
        float deltaX = lookAt.position.x - transform.position.x;
        // Checking if we are in bounds on X axis.
        if (deltaX > boundX | deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // Adding the delta to the current position.
        transform.position += new Vector3(delta.x, 7.5f, 0);

        // Making sure that the y position stays the same.
        var tp = transform.position;
        tp.y = 7.5f;
        transform.position = tp;
    }
    void Update()
    {
        Vector2 diff = lookAt.transform.position - gameObject.transform.position;
        gameObject.transform.position += (Vector3)(Time.deltaTime * diff);
    }
}
