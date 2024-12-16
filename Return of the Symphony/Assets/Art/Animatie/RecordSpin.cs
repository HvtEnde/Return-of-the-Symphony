using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordSpin : MonoBehaviour
{
    // Speed of rotation in degrees per second
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Rotate around Y-axis by default

    void Update()
    {
        // Rotate the object
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
