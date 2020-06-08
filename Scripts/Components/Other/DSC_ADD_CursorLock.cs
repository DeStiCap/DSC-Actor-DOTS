using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]  
    public struct DSC_ADD_CursorLock : IComponentData
    {
        public CursorLockMode m_eLockMode;

        [HideInInspector]
        public CursorLockMode m_ePreviousMode;
    }
}