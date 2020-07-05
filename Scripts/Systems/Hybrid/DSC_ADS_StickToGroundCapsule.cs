using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADS_StickToGround_Pre))]
    [UpdateBefore(typeof(DSC_ADS_StickToGround))]
    public sealed class DSC_ADS_StickToGroundCapsule : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform
                ,Rigidbody hRigid
                ,CapsuleCollider hCol
                ,ref DSC_ADD_StickToGround hStick
                ,ref DSC_ADD_GroundCheck hGround
                ,ref DSC_ADD_Jump hJump) =>
            {
                if (transform == null
                || hRigid == null
                || hCol == null
                || hGround.m_bOnGround
                || !hGround.m_bOnGroundPrevious
                || hJump.m_bJumping)
                    return;

                RaycastHit hitInfo;
                if (Physics.SphereCast(transform.position, hCol.radius, Vector3.down, out hitInfo,
                                       ((hCol.height * 0.5f) - hCol.radius) +
                                       hStick.m_fStickToGroundDistance, hGround.m_eGroundLayer, QueryTriggerInteraction.Ignore))
                {
                    if (Mathf.Abs(Vector3.Angle(hitInfo.normal, Vector3.up)) <= hStick.m_fMaxStickGroundAngle)
                    {
                        hRigid.velocity = Vector3.ProjectOnPlane(hRigid.velocity, hitInfo.normal);
                    }
                }

            }).WithoutBurst()
            .Run();
        }
    }
}