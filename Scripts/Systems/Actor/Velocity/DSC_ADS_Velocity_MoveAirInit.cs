using DSC.Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_FixedUpdate_Normal))]
    [UpdateBefore(typeof(DSC_ADS_Velocity_Move))]
    public sealed partial class DSC_ADS_Velocity_MoveAirInit : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_Velocity hVelocity
                , in Rotation hRotation
                , in DSC_ADD_Move hMove       
                , in DSC_ADD_GroundCheck hGround) =>
            {
                if (hMove.m_fDeltaTimePrevious == 0
                || hMove.m_bAirControl
                || hGround.m_bOnGround == hGround.m_bOnGroundPrevious
                || math.all(hMove.m_f3MovePrevious == float3.zero))
                    return;

                var f3UpDirection = MathUtility.GetDirectionByRotation(hRotation.Value, DirectionType.Up);

                if (hGround.m_bOnGroundPrevious)
                {
                    if (math.all(hMove.m_f3MovePrevious == float3.zero))
                        return;


                    var f3MoveVelocity = hMove.m_f3MovePrevious;

                    var f3VerticalVelocity = MathUtility.ExtractDotVector(f3MoveVelocity, f3UpDirection);
                    var f3HorizontalVelocity = f3MoveVelocity - f3VerticalVelocity;

                    hVelocity.m_f3Velocity += f3HorizontalVelocity / hMove.m_fDeltaTimePrevious;
                }
                else
                {
                    var f3VertiCalVelocity = MathUtility.ExtractDotVector(hVelocity.m_f3Velocity, f3UpDirection);
                    hVelocity.m_f3Velocity = f3VertiCalVelocity;
                }

            }).ScheduleParallel();
        }
    }
}