using Unity.Entities;
using UnityEngine;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Run : IComponentData
    {
        public InputButtonType m_eButton;
        public GetInputType m_eInputType;
        [Min(0)]
        public float m_fSpeedMultiplier;

        [HideInInspector]
        public bool m_bRunning;
    }
}