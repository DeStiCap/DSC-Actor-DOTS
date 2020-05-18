using Unity.Entities;

namespace DSC.Actor.DOTS
{
    #region Enum

    public enum RigidbodyType
    {
        Rigidbody3D,
        Rigidbody2D
    }

    #endregion

    [GenerateAuthoringComponent]
    public struct DSC_ADD_RigidbodyType : IComponentData
    {
        public RigidbodyType Value;
    }
}