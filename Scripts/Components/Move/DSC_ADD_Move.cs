using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Move : IComponentData
    {
        public bool m_bAirControl;

        [HideInInspector]
        public bool m_bHasMove;

        [HideInInspector]
        public float3 m_f3Move;
    }
}