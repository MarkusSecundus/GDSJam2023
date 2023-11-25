using MarkusSecundus.PhysicsSwordfight.Utils.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarkusSecundus.PhysicsSwordfight.Cosmetics
{
    /// <summary>
    /// Synchronizes transform of a <see cref="Camera"/> object with another transform each frame.
    /// </summary>
    public class CameraFollowPoint : MonoBehaviour
    {
        public float LerpFactor = 1f;
        /// <summary>
        /// Transform to follow
        /// </summary>
        public Transform Target;
        private void LateUpdate()
        {
            if (Target.IsNotNil())
            {
                (transform.position, transform.rotation, transform.localScale) = (
                    Vector3.Lerp(transform.position, Target.position, LerpFactor), 
                    Quaternion.Lerp(transform.rotation, Target.rotation, LerpFactor), 
                    Vector3.Lerp(transform.localScale, Target.localScale, LerpFactor));

            }
        }
    }
}