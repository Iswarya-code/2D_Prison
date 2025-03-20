using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    public Transform targetTransform;
    public float cameraDampingTime;
    public float cameraZOffset;
    public Vector3 offset;

    Vector3 refVelocity;


    private void FixedUpdate()
    {
        var targetPosition = targetTransform.position;
        targetPosition.z = cameraZOffset;

        transform.position = Vector3.SmoothDamp
            (
                transform.position, 
                targetPosition + offset, 
                ref refVelocity, 
                cameraDampingTime
            );
    }
}
