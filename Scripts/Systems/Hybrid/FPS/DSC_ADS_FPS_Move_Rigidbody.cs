using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateAfter(typeof(DSC_ADS_Move_Pre))]
    [UpdateBefore(typeof(DSC_ADS_Move))]
    public sealed class DSC_ADS_FPS_Move_Rigidbody : SystemBase
    {
        protected override void OnUpdate()
        {
            var vCamForward = Camera.main.transform.forward;
            var vCamRight = Camera.main.transform.right;

            Entities.WithAll<DSC_ADT_FPS>()
                .ForEach((Rigidbody hRigid
                , ref DSC_ADD_Input hInput
                , ref DSC_ADD_Move hMove
                , ref DSC_ADD_MoveSpeed3D hSpeed
                , ref DSC_ADD_GroundCheck hGround) =>
            {
                var f2Axis = hInput.m_hAxis.m_f2Axis;

                if (hRigid == null
                || (!hGround.m_bOnGround && !hMove.m_bAirControl)
                || math.all(f2Axis == float2.zero))
                    return;

                var vDesiredMove = vCamForward * f2Axis.y + vCamRight * f2Axis.x;
                vDesiredMove = Vector3.ProjectOnPlane(vDesiredMove, hGround.m_f3GroundNormal);

                float fCurrentTargetSpeed = hSpeed.m_fCurrentSpeed;

                vDesiredMove *= fCurrentTargetSpeed;
                if (hRigid.velocity.sqrMagnitude < fCurrentTargetSpeed * fCurrentTargetSpeed)
                {
                    hRigid.AddForce(vDesiredMove, ForceMode.Impulse);
                }

            }).WithoutBurst()
            .Run();
        }
    }
}