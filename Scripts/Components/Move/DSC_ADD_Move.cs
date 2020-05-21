using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Move : IComponentData
    {
        [HideInInspector]
        public bool bHasMove;
        [HideInInspector]
        public float3 f3Move;
    }
}