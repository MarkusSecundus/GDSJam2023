using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Animations.Rigging;
using UnityEngine.Animations;
using UnityEngine;

namespace Assets.Scripts.Utils.Geometry
{/*
    public static class IKHelpers
    {
        public static void SolveTwoBoneIK(
           AnimationStream stream,
           ReadWriteTransformHandle root,
           ReadWriteTransformHandle mid,
           ReadWriteTransformHandle tip,
           ReadOnlyTransformHandle target,
           ReadOnlyTransformHandle hint,
           float posWeight,
           float rotWeight,
           float hintWeight,
           AffineTransform targetOffset
           )
        {
            Vector3 aPosition = root.GetPosition(stream);
            Vector3 bPosition = mid.GetPosition(stream);
            Vector3 cPosition = tip.GetPosition(stream);
            target.GetGlobalTR(stream, out Vector3 targetPos, out Quaternion targetRot);
            Vector3 tPosition = Vector3.Lerp(cPosition, targetPos + targetOffset.translation, posWeight);
            Quaternion tRotation = Quaternion.Lerp(tip.GetRotation(stream), targetRot * targetOffset.rotation, rotWeight);
            bool hasHint = hint.IsValid(stream) && hintWeight > 0f;

            Vector3 ab = bPosition - aPosition;
            Vector3 bc = cPosition - bPosition;
            Vector3 ac = cPosition - aPosition;
            Vector3 at = tPosition - aPosition;

            float abLen = ab.magnitude;
            float bcLen = bc.magnitude;
            float acLen = ac.magnitude;
            float atLen = at.magnitude;

            float oldAbcAngle = TriangleAngle(acLen, abLen, bcLen);
            float newAbcAngle = TriangleAngle(atLen, abLen, bcLen);

            // Bend normal strategy is to take whatever has been provided in the animation
            // stream to minimize configuration changes, however if this is collinear
            // try computing a bend normal given the desired target position.
            // If this also fails, try resolving axis using hint if provided.
            Vector3 axis = Vector3.Cross(ab, bc);
            if (axis.sqrMagnitude < k_SqrEpsilon)
            {
                axis = hasHint ? Vector3.Cross(hint.GetPosition(stream) - aPosition, bc) : Vector3.zero;

                if (axis.sqrMagnitude < k_SqrEpsilon)
                    axis = Vector3.Cross(at, bc);

                if (axis.sqrMagnitude < k_SqrEpsilon)
                    axis = Vector3.up;
            }
            axis = Vector3.Normalize(axis);

            float a = 0.5f * (oldAbcAngle - newAbcAngle);
            float sin = Mathf.Sin(a);
            float cos = Mathf.Cos(a);
            Quaternion deltaR = new Quaternion(axis.x * sin, axis.y * sin, axis.z * sin, cos);
            mid.SetRotation(stream, deltaR * mid.GetRotation(stream));

            cPosition = tip.GetPosition(stream);
            ac = cPosition - aPosition;
            root.SetRotation(stream, QuaternionExt.FromToRotation(ac, at) * root.GetRotation(stream));

            if (hasHint)
            {
                float acSqrMag = ac.sqrMagnitude;
                if (acSqrMag > 0f)
                {
                    bPosition = mid.GetPosition(stream);
                    cPosition = tip.GetPosition(stream);
                    ab = bPosition - aPosition;
                    ac = cPosition - aPosition;

                    Vector3 acNorm = ac / Mathf.Sqrt(acSqrMag);
                    Vector3 ah = hint.GetPosition(stream) - aPosition;
                    Vector3 abProj = ab - acNorm * Vector3.Dot(ab, acNorm);
                    Vector3 ahProj = ah - acNorm * Vector3.Dot(ah, acNorm);

                    float maxReach = abLen + bcLen;
                    if (abProj.sqrMagnitude > (maxReach * maxReach * 0.001f) && ahProj.sqrMagnitude > 0f)
                    {
                        Quaternion hintR = QuaternionExt.FromToRotation(abProj, ahProj);
                        hintR.x *= hintWeight;
                        hintR.y *= hintWeight;
                        hintR.z *= hintWeight;
                        hintR = QuaternionExt.NormalizeSafe(hintR);
                        root.SetRotation(stream, hintR * root.GetRotation(stream));
                    }
                }
            }

            tip.SetRotation(stream, tRotation);

        }
    */
}