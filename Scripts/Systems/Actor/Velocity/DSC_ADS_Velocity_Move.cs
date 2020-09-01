using Unity.Entities;
using Unity.Mathematics;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_PostNormal))]
    public sealed class DSC_ADS_Velocity_Move : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDeltaTime = Time.DeltaTime;

            Entities.ForEach((ref DSC_ADD_Move hMove
                , in DSC_ADD_Velocity hVelocity) =>
            {
                if (math.all(hVelocity.m_f3Velocity == float3.zero))
                    return;

                hMove.m_bHasMove = true;
                hMove.m_f3Move += hVelocity.m_f3Velocity * fDeltaTime;

            }).ScheduleParallel();
        }
    }
}