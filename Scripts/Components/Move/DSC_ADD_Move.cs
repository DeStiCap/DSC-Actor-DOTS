﻿using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_Move : IComponentData
    {
        public bool m_bAirControl;
    }
}