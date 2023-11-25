using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceIntoPosition : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float force;
    [SerializeField] ForceMode mode = ForceMode.Force;
    [SerializeField] bool doNormalize = true;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var direction = target.position - rb.position;
        if (doNormalize) direction = direction.normalized;
        rb.AddForce(direction * force, mode);
    }
}
