using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early))]
    [UpdateAfter(typeof(DSC_ADG_GroundCheck))]
    public sealed class DSC_ADS_MoveSlopeCheck : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform
                ,DSC_ADM_MoveSlopeCurve hCurve
                ,ref DSC_ADD_MoveSlope hSlope
                ,ref DSC_ADD_GroundCheck hGround) =>
            {
                if (transform == null
                || hCurve.Value == null)
                    return;

                hSlope.m_fSpeedMultiplier = hCurve.Value.Evaluate(
                    Vector3.Angle(hGround.m_f3GroundNormal, transform.up));

            }).WithoutBurst()
            .Run();
        }
    }
}