using Unity.Mathematics;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    public static class MathUtility
    {
        const float m_fEpsilonNormalSqrt = 1e-15f;
        const float m_fEpisilon = 1.17549435E-38f;

        // Sign function that has the old Mathf behaviour of returning 1 if f == 0
        static float MathfStyleZeroIsOneSign(float f)
        {
            return f >= 0f ? 1f : -1f;
        }

        //
        public static float SignedAngle(float fA, float fB)
        {
            float fDifference = fB - fA;
            float fSign = math.sign(fDifference);
            float fOffset = fSign * 180.0f;

            return ((fDifference + fOffset) % 360.0f) - fOffset;
        }

        public static float SignedAngle(float3 f3From, float3 f3To, float3 f3Axis)
        {
            float fUnsignedAngle = Angle(f3From, f3To);
            float fSign = MathfStyleZeroIsOneSign(math.dot(f3Axis, math.cross(f3From, f3To)));
            float fResult = fUnsignedAngle * fSign;

            return fResult;
        }


        public static float Angle(float3 f3From, float3 f3To)
        {
            float fResult;

            // sqrt(a) * sqrt(b) = sqrt(a * b) -- valid for real numbers
            float fDenominator = math.sqrt(math.lengthsq(f3From) * math.lengthsq(f3To));

            if (fDenominator < m_fEpsilonNormalSqrt)
            {
                fResult = 0F;
            }
            else
            {
                float fDot = math.clamp(math.dot(f3From, f3To) / fDenominator, -1F, 1F);
                fResult = math.degrees(math.acos(fDot));
            }

            return fResult;
        }

        public static float3 Project(float3 f3Vector, float3 f3OnNormal)
        {
            float3 f3Result;

            float fSqrMag = math.dot(f3OnNormal, f3OnNormal);
            if (fSqrMag < m_fEpisilon)
                f3Result = float3.zero;
            else
                f3Result = f3OnNormal * math.dot(f3Vector, f3OnNormal) / fSqrMag;
            return f3Result;
        }

        public static float3 ProjectOnPlane(float3 f3Vector, float3 f3PlaneNormal)
        {
            var f3Result = f3Vector - Project(f3Vector, f3PlaneNormal);
            return f3Result;
        }

        /// <summary>
        /// Extract parts from vector that are pointing in this direction.
        /// </summary>
        /// <param name="f3Vector"></param>
        /// <param name="f3Direction"></param>
        /// <returns>Extract vector</returns>
        public static float3 ExtractDotVector(float3 f3Vector, float3 f3Direction)
        {
            return ExtractDotVector(f3Vector, f3Direction, out _);
        }

        /// <summary>
        /// Extract parts from vector that are pointing in this direction.
        /// </summary>
        /// <param name="f3Vector"></param>
        /// <param name="f3Direction"></param>
        /// <param name="fScalar"></param>
        /// <returns>Extract vector</returns>
        public static float3 ExtractDotVector(float3 f3Vector, float3 f3Direction,out float fScalar)
        {
            //Normalize direction if necessary.
            if (math.lengthsq(f3Direction) != 1)
                f3Direction = math.normalize(f3Direction);

            fScalar = math.dot(f3Vector, f3Direction);

            return f3Direction * fScalar;
        }

        public static float3 EulerAngles(quaternion rot)
        {
            float4 q1 = rot.value;
            float sqw = q1.w * q1.w;
            float sqx = q1.x * q1.x;
            float sqy = q1.y * q1.y;
            float sqz = q1.z * q1.z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = q1.x * q1.w - q1.y * q1.z;
            float3 v;

            if (test > 0.4995f * unit)
            { // singularity at north pole
                v.y = 2f * math.atan2(q1.y, q1.x);
                v.x = math.PI / 2f;
                v.z = 0;
                return NormalizeAngles(v);
            }
            if (test < -0.4995f * unit)
            { // singularity at south pole
                v.y = -2f * math.atan2(q1.y, q1.x);
                v.x = -math.PI / 2;
                v.z = 0;
                return NormalizeAngles(v);
            }

            rot = new quaternion(q1.w, q1.z, q1.x, q1.y);
            v.y = math.atan2(2f * rot.value.x * rot.value.w + 2f * rot.value.y * rot.value.z, 1 - 2f * (rot.value.z * rot.value.z + rot.value.w * rot.value.w));     // Yaw
            v.x = math.asin(2f * (rot.value.x * rot.value.z - rot.value.w * rot.value.y));                             // Pitch
            v.z = math.atan2(2f * rot.value.x * rot.value.y + 2f * rot.value.z * rot.value.w, 1 - 2f * (rot.value.y * rot.value.y + rot.value.z * rot.value.z));      // Roll

            return ConvertEulerToUnityAngle(NormalizeAngles(v));
        }

        static float3 NormalizeAngles(float3 angles)
        {
            angles.x = NormalizeAngle(angles.x);
            angles.y = NormalizeAngle(angles.y);
            angles.z = NormalizeAngle(angles.z);
            return angles;
        }

        static float NormalizeAngle(float angle)
        {
            while (angle > math.PI * 2f)
                angle -= math.PI * 2f;
            while (angle < 0)
                angle += math.PI * 2f;
            return angle;
        }

        /// <summary>
        /// Need to use this method to convert to same angle in Unity.
        /// </summary>
        /// <param name="f3Angles"></param>
        /// <returns></returns>
        static float3 ConvertEulerToUnityAngle(float3 f3Angles)
        {
            f3Angles *= 57.3f;

            f3Angles.x = (float) System.Math.Round(f3Angles.x, 1);
            f3Angles.y = (float) System.Math.Round(f3Angles.y, 1);
            f3Angles.z = (float) System.Math.Round(f3Angles.z, 1);

            return f3Angles;
        }

        public static float3 GetDirectionByRotation(quaternion qValue, DirectionType eType)
        {
            float3 f3Result = float3.zero;

            switch (eType)
            {
                case DirectionType.Forward:
                    f3Result = math.mul(qValue, new float3(0, 0, 1));
                    break;

                case DirectionType.Backward:
                    f3Result = math.mul(qValue, new float3(0, 0, -1));
                    break;

                case DirectionType.Right:
                    f3Result = math.mul(qValue, new float3(1, 0, 0));
                    break;

                case DirectionType.Left:
                    f3Result = math.mul(qValue, new float3(-1, 0, 0));
                    break;

                case DirectionType.Up:
                    f3Result = math.mul(qValue, new float3(0, 1, 0));
                    break;

                case DirectionType.Down:
                    f3Result = math.mul(qValue, new float3(0, -1, 0));
                    break;
            }

            return f3Result;
        }
    }
}