using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    public sealed class DSC_ADS_CursorLock : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_CursorLock hCursor) =>
            {
                if (hCursor.m_eLockMode == hCursor.m_ePreviousMode)
                    return;

                bool bLocking = hCursor.m_eLockMode != CursorLockMode.None;

                Cursor.visible = !bLocking;
                Cursor.lockState = hCursor.m_eLockMode;
                hCursor.m_ePreviousMode = hCursor.m_eLockMode;
            }).WithoutBurst()
            .Run();
        }
    }
}