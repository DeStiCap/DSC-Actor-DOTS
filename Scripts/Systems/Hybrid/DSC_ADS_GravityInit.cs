using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public sealed class DSC_ADS_GravityInit : SystemBase
    {
        protected override void OnUpdate()
        {
            float fGravity = Physics.gravity.y;

            Entities.ForEach((ref DSC_ADD_Gravity hGravity) =>
            {
                if (hGravity.m_bOverride)
                    hGravity.m_fGravity = hGravity.m_fOverrideGravity;
                else
                    hGravity.m_fGravity = fGravity;

            }).ScheduleParallel();
        }
    }
}