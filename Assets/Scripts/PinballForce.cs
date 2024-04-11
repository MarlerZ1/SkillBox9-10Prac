using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class FinballForce : MonoBehaviour
{
    [SerializeField] private Transform preparingPosition;
    [SerializeField] private Transform launchingPosition;

    [SerializeField] private float launchSpeed = 10f;
    [SerializeField] private float returnSpeed = 2f;

    [SerializeField] private float returnDelay = 2f;
    [SerializeField] private float waitTime = 1f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(WorkSpring());
    }

    private IEnumerator WorkSpring()
    {
        while (true)
        {
            yield return StartCoroutine(Launch());
            yield return StartCoroutine(Return());
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator Launch()
    {
        while (Vector3.Distance(transform.position, launchingPosition.position) > 0.1f)
        {
            _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, launchingPosition.position, launchSpeed * Time.deltaTime));
            yield return null;
        }
    }

    private IEnumerator Return()
    {
        yield return new WaitForSeconds(returnDelay);

        while (Vector3.Distance(transform.position, preparingPosition.position) > 0.1f)
        {
            _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, preparingPosition.position, returnSpeed * Time.deltaTime));
            yield return null;
        }
    }
}

