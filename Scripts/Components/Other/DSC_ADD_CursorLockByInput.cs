using Unity.Entities;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public struct DSC_ADD_CursorLockByInput : IComponentData
    {
        public InputButtonType m_eLockButton;
        public InputButtonType m_eUnlockButton;
    }
}