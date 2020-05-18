using Unity.Entities;
using Unity.Mathematics;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_MoveContinuous : IComponentData
    {
        public float3 Value;
    }
}