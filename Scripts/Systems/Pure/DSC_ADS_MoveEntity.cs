using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(DSC_ADS_CopyPositionEntity))]
    public sealed class DSC_ADS_MoveEntity : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            inputDeps = Entities.ForEach((ref Translation hTrans
                , ref DSC_ADD_Move hMoveData) =>
            {
                if (!hMoveData.bHasMove)
                    return;

                hTrans.Value += hMoveData.f3Move;

                hMoveData.bHasMove = false;
                hMoveData.f3Move = float3.zero;

            }).WithNone<DSC_ADD_MoveGameObjectType>()
            .Schedule(inputDeps);

            return inputDeps;
        }
    }
}