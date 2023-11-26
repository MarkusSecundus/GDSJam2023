using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionBehavior : MonoBehaviour
{
    Vector3 distanceFromParent;
    void Start()
    {
        distanceFromParent = transform.position - transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position + distanceFromParent;
        transform.rotation = Quaternion.LookRotation(transform.parent.position - transform.position, Vector3.up);
    }
}
