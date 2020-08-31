using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early))]
    [UpdateAfter(typeof(DSC_ADS_GravityInit))]
    public sealed class DSC_ADS_Velocity_Gravity : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDeltaTime = Time.DeltaTime;

            Entities.ForEach((ref Rotation hRotation
                , ref DSC_ADD_Velocity hVelocity
                , ref DSC_ADD_Gravity hGravity
                , ref DSC_ADD_GroundCheck hGround) =>
            {

                float3 f3UpDirection = MathUtility.GetDirectionByRotation(hRotation.Value, Core.DirectionType.Up);
                var f3VerticalVelocity = MathUtility.ExtractDotVector(hVelocity.m_f3Velocity, f3UpDirection, out var fVelocityScalar);
                var f3HorizontalVelocity = hVelocity.m_f3Velocity - f3VerticalVelocity;

                if (hGround.m_bOnGround)
                {
                    if (fVelocityScalar < 0)
                    {
                        f3VerticalVelocity = float3.zero;
                        hVelocity.m_f3Velocity = f3HorizontalVelocity + f3VerticalVelocity;
                    }
                    return;
                }

                f3VerticalVelocity += f3UpDirection * hGravity.m_fGravity * hGravity.m_fMultiplier * fDeltaTime;

                hVelocity.m_f3Velocity = f3HorizontalVelocity + f3VerticalVelocity;

            }).ScheduleParallel();
        }
    }
}