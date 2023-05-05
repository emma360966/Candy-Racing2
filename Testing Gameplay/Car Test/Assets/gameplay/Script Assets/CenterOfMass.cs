// Expose center of mass to allow it to be set from
// the inspector.
using UnityEngine;
using System.Collections;
//This script was made for when the car needed one, back when I was testing another model for gameplay.
//Legacy code
//Feel free to delete, shouldn't change anything
public class CenterOfMass : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }
}