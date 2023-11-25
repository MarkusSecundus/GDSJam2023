using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExchangeCharacterForConfigurableJoint : MonoBehaviour
{
    public GameObject Root;
    public void DoRun()
    {
        Debug.Log("Running!");
        foreach(var c in Root.GetComponentsInChildren<CharacterJoint>())
        {
            var conf = c.AddComponent<ConfigurableJoint>();
            conf.connectedBody = c.connectedBody;
            conf.axis = c.axis;
            conf.secondaryAxis = c.swingAxis;

            conf.xMotion = ConfigurableJointMotion.Locked;
            conf.yMotion = ConfigurableJointMotion.Locked;
            conf.zMotion = ConfigurableJointMotion.Locked;
            conf.angularXMotion = ConfigurableJointMotion.Limited;
            conf.angularYMotion = ConfigurableJointMotion.Limited;
            conf.angularZMotion = ConfigurableJointMotion.Limited;

            conf.lowAngularXLimit = c.lowTwistLimit;
            conf.highAngularXLimit = c.highTwistLimit;
            conf.angularYLimit = c.swing1Limit;
            conf.angularZLimit = c.swing2Limit;
            conf.rotationDriveMode = RotationDriveMode.Slerp;
        }
    }

    public void DestroyAll()
    {
        var cc = Root.GetComponentsInChildren<CharacterJoint>();
        Debug.Log($"Destroying! {cc.Length} objs");
        foreach (var c in cc)
        {
            DestroyImmediate(c);
        }
    }
}
