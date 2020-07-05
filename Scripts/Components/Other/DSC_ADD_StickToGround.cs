using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_StickToGround : IComponentData
    {
        public float m_fMaxStickGroundAngle;
        public float m_fStickToGroundDistance;
    }
}