using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_MoveSpeed3D : IComponentData
    {
        [Min(0)]
        public float m_fForwardSpeed;
        [Min(0)]
        public float m_fBackwardSpeed;
        [Min(0)]
        public float m_fStrafeSpeed;

        [HideInInspector]
        public float m_fCurrentSpeed;
    }
}