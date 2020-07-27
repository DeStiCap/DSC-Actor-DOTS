using Unity.Entities;
using Unity.Mathematics;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Velocity : IComponentData
    {
        public float3 m_f3Velocity;
    }
}