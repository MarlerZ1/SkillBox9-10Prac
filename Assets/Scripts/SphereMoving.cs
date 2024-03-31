using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereMoving : MonoBehaviour
{
    [SerializeField] private float force;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
    }

    
}
