using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Adjust this value to control the rotation speed
    public float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get the direction vector from the character's position to the mouse position
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction.Normalize();

        // Calculate the angle in radians and convert it to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the character smoothly towards the mouse position
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

