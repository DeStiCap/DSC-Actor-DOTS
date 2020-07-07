using Unity.Entities;
using UnityEngine;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Jump : IComponentData
    {
        public InputButtonType m_eButton;
        [Min(0)]
        public float m_fForce;

        [HideInInspector]
        public bool m_bJumping;

        [HideInInspector]
        public double m_fJumpStartTime;
    }
}