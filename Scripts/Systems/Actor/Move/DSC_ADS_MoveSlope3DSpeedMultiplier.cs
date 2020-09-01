using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Normal))]
    public sealed class DSC_ADS_MoveSlope3DSpeedMultiplier : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_MoveSpeed3D hSpeed
                , in DSC_ADD_MoveSlope hSlope) =>
            {
                hSpeed.m_fCurrentSpeed *= hSlope.m_fSpeedMultiplier;
            }).ScheduleParallel();
        }
    }
}