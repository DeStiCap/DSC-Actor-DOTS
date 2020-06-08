using Unity.Entities;
using UnityEngine;
using DSC.Core;
using Unity.Mathematics;

namespace DSC.Actor.DOTS
{
    #region Data

    public struct InputAxisData
    {
        public float2 m_f2RawAxis;
        public float2 m_f2Axis;

        public DirectionType2D m_eAxisPress;
        public DirectionType2D m_eAxisDoublePress;
        public DirectionType2D m_eAxisTap;
        public DirectionType2D m_eAxisDoubleTap;
    }

    #endregion

    [GenerateAuthoringComponent]
    public struct DSC_ADD_Input : IComponentData
    {
        public InputAxisData m_hAxis;
        public InputAxisData m_hAxis2;

        [HideInInspector]
        public InputButtonType m_eButtonDown;
        [HideInInspector]
        public InputButtonType m_eButtonHold;
        [HideInInspector]
        public InputButtonType m_eButtonUp;
    }
}