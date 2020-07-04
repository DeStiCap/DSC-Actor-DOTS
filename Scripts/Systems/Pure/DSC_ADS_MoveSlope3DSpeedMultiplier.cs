using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateBefore(typeof(DSC_ADS_Move_Pre))]
    [UpdateAfter(typeof(DSC_ADS_CurrentMoveSpeed3DByInput))]
    public sealed class DSC_ADS_MoveSlope3DSpeedMultiplier : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_MoveSlope hSlope
                ,ref DSC_ADD_MoveSpeed3D hSpeed) =>
            {
                hSpeed.m_fCurrentSpeed *= hSlope.m_fSpeedMultiplier;
            }).ScheduleParallel();
        }
    }
}