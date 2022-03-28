using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_StickToGround))]
    public sealed partial class DSC_ADS_StickToGroundCapsule : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform
                ,Rigidbody hRigid
                ,CapsuleCollider hCol
                ,in DSC_ADD_StickToGround hStick
                ,in DSC_ADD_GroundCheck hGround
                ,in DSC_ADD_Jump hJump) =>
            {
                if (transform == null
                || hRigid == null
                || hCol == null
                || hGround.m_bOnGround
                || !hGround.m_bOnGroundPrevious
                || hJump.m_bJumping)
                    return;

                if (Physics.SphereCast(transform.position, hCol.radius, -transform.up, out RaycastHit hitInfo,
                                       ((hCol.height * 0.5f) - hCol.radius) +
                                       hStick.m_fStickToGroundDistance, hGround.m_eGroundLayer, QueryTriggerInteraction.Ignore))
                {
                    if (math.abs(MathUtility.Angle(hitInfo.normal, transform.up)) <= hStick.m_fMaxStickGroundAngle)
                    {
                        hRigid.velocity = MathUtility.ProjectOnPlane(hRigid.velocity, hitInfo.normal);
                    }
                }

            }).WithoutBurst()
            .Run();
        }
    }
}