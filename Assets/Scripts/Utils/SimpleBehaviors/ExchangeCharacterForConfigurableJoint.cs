using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExchangeCharacterForConfigurableJoint : MonoBehaviour
{
    public GameObject Root;
    public void DoRun()
    {
        foreach(var c in Root.GetComponentsInChildren<CharacterJoint>())
        {
            var conf = c.AddComponent<ConfigurableJoint>();
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

            Destroy(c);
        }
    }
}
