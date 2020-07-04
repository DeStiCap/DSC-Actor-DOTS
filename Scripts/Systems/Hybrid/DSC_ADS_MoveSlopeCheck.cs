﻿using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADS_GroundCheck))]
    public sealed class DSC_ADS_MoveSlopeCheck : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((DSC_ADM_MoveSlopeCurve hCurve
                ,ref DSC_ADD_MoveSlope hSlope
                ,ref DSC_ADD_GroundCheck hGround) =>
            {
                if (hCurve.Value == null)
                    return;

                hSlope.m_fSpeedMultiplier = hCurve.Value.Evaluate(
                    Vector3.Angle(hGround.m_f3GroundNormal, Vector3.up));

            }).WithoutBurst()
            .Run();
        }
    }
}