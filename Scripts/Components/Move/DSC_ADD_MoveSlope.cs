using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_MoveSlope : IComponentData
    {
        [HideInInspector]
        public float m_fSpeedMultiplier;
    }
}