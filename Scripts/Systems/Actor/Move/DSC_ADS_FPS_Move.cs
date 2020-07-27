using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Move))]
    public sealed class DSC_ADS_FPS_Move : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDeltaTime = Time.DeltaTime;

            var vCamForward = Camera.main.transform.forward;
            var vCamRight = Camera.main.transform.right;

            Entities.WithAll<DSC_ADT_FPS>()
                .ForEach((ref DSC_ADD_Input hInput
                , ref DSC_ADD_Move hMove
                , ref DSC_ADD_MoveSpeed3D hSpeed
                , ref DSC_ADD_GroundCheck hGround) =>
            {
                var f2Axis = hInput.m_hAxis.m_f2Axis;

                if (!hGround.m_bOnGround && !hMove.m_bAirControl
                || math.all(f2Axis == float2.zero))
                    return;

                var vDesiredMove = vCamForward * f2Axis.y + vCamRight * f2Axis.x;
                vDesiredMove = MathUtility.ProjectOnPlane(vDesiredMove, hGround.m_f3GroundNormal);

                float fCurrentTargetSpeed = hSpeed.m_fCurrentSpeed;

                vDesiredMove *= fCurrentTargetSpeed * fDeltaTime;

                hMove.m_bHasMove = true;
                hMove.m_f3Move += (float3)vDesiredMove;
            })
            .ScheduleParallel();
        }
    }
}