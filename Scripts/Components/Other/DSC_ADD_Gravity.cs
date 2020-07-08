using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Gravity : IComponentData
    {
        [HideInInspector]
        public float m_fGravity;

        public float m_fMultiplier;
        
        [Header("Override")]
        public bool m_bOverride;
        public float m_fOverrideGravity;
    }
}