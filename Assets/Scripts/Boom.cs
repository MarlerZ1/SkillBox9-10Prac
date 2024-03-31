using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float timeToExplosion;
    [SerializeField] private float power;
    [SerializeField] private float radius;


    private float standartTime;
    void Start()
    {
        standartTime = timeToExplosion;
    }

    // Update is called once per frame
    private void Update()
    {
        timeToExplosion -= Time.deltaTime;

        if (timeToExplosion <= 0)
        {
            BoomAddForce();
        }
    }

    private void BoomAddForce() 
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();


        foreach (Rigidbody rb in blocks)
        {
            if (Vector3.Distance(transform.position, rb.transform.position) < radius)
            {
                Vector3 direction = rb.transform.position - transform.position;

                rb.AddForce(direction.normalized * power * (radius - Vector3.Distance(transform.position, rb.transform.position)), ForceMode.Impulse);
            } 
                
        }

        timeToExplosion = standartTime;
    }
}
