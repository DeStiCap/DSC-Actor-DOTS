using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_CameraCMRotate : IComponentData
    {
        [Min(0)]
        public float m_fSensitiveX;
        [Min(0)]
        public float m_fSensitiveY;

        public bool m_bSmooth;
        public float m_fSmoothTime;

        public bool m_bClampVertical;
        public float m_fVerticalMin;
        public float m_fVerticalMax;
    }
}