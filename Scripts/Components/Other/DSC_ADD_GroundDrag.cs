using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_GroundDrag : IComponentData
    {
        public float Value;
    }
}