using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace DSC.Actor.DOTS
{
    public sealed class DSC_ADS_MoveContinuous : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float fDeltaTime = Time.DeltaTime;

            inputDeps = Entities.ForEach((ref DSC_ADD_MoveContinuous hDirectionData
                ,ref DSC_ADD_Move hMoveData) =>
            {
                if (math.all(hDirectionData.Value == float3.zero))
                    return;

                hMoveData.f3Move += hDirectionData.Value * fDeltaTime;
                hMoveData.bHasMove = true;

            }).Schedule(inputDeps);

            return inputDeps;
        }
    }
}