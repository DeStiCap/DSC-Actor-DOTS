using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_MoveSpeed : IComponentData
    {
        [Min(0)]
        public float Value;
    }
}