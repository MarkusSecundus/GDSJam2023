using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFootToPosition : MonoBehaviour
{
    public Transform target;

    ConfigurableJoint joint;
    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
    }
}
