using MarkusSecundus.PhysicsSwordfight.PhysicsUtils;
using MarkusSecundus.PhysicsSwordfight.Utils.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateJointAccordingToTarget : MonoBehaviour
{

    [SerializeField] Transform NamespaceRoot;

    ConfigurableJoint _joint;
    JointRotationHelper _rotator;

    public Transform _target;
    void Start()
    {
        _joint = GetComponent<ConfigurableJoint>();
        _joint.configuredInWorldSpace = true;
        _rotator = new JointRotationHelper(_joint);
        _target = NamespaceRoot.FindRecursive(this.name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rotator.SetTargetRotation(_target.rotation);
    }
}
