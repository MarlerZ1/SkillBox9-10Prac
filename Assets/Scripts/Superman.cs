using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Superman : MonoBehaviour
{
    [SerializeField] private float damageForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            print("Bad");
            if (rb)
            {
                print("Damaged");
                rb.AddForce((collision.transform.position - gameObject.transform.position).normalized * damageForce, ForceMode.Impulse);
            }
        }
    }
}
