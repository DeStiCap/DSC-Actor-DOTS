using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_GroundCheck : IComponentData
    {
        [Min(0)]
        public float m_fCheckDistance;
        public LayerMask m_eGroundLayer;

        [HideInInspector]
        public bool m_bOnGround;
        [HideInInspector]
        public bool m_bOnGroundPrevious;

        [HideInInspector]
        public float3 m_f3GroundNormal;
    }
}