using Unity.Entities;

namespace DSC.Actor.DOTS
{
    #region Enum

    public enum CopyMoveType
    {
        Transform,
        Rigidbody
    }

    #endregion

    [GenerateAuthoringComponent]
    public struct DSC_ADD_CopyMoveType : IComponentData
    {
        public CopyMoveType Value;
    }
}