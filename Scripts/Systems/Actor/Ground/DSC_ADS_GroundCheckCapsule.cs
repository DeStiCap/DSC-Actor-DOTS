using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_GroundCheck))]
    public sealed class DSC_ADS_GroundCheckCapsule : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform,CapsuleCollider hCol
                ,ref DSC_ADD_GroundCheck hCheck) =>
            {
                if (transform == null || hCol == null)
                    return;

                hCheck.m_bOnGroundPrevious = hCheck.m_bOnGround;

                if(Physics.SphereCast(transform.position + hCol.center, hCol.radius, -transform.up, out var hHitInfo
                    , (hCol.height * 0.5f) - hCol.radius + hCheck.m_fCheckDistance, hCheck.m_eGroundLayer, QueryTriggerInteraction.Ignore))
                {
                    hCheck.m_bOnGround = true;
                    hCheck.m_f3GroundNormal = hHitInfo.normal;
                }
                else
                {
                    hCheck.m_bOnGround = false;
                    hCheck.m_f3GroundNormal = transform.up;
                }

            }).WithoutBurst()
            .Run();
        }
    }
}