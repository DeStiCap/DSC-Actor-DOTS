using Unity.Entities;

namespace DSC.Actor.DOTS
{
    #region Enum

    public enum MoveGameObjectType
    {
        Transform,
        Rigidbody
    }

    #endregion

    [GenerateAuthoringComponent]
    public struct DSC_ADD_MoveGameObjectType : IComponentData
    {
        public MoveGameObjectType Value;
    }
}