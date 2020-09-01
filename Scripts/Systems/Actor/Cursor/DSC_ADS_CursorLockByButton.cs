using Unity.Entities;
using UnityEngine;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Normal))]
    [UpdateBefore(typeof(DSC_ADS_CursorLock))]
    public sealed class DSC_ADS_CursorLockByButton : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_CursorLock hCursor
                , in DSC_ADD_CursorLockByInput hLockInput                
                , in DSC_ADD_Input hInput) =>
            {
                if (FlagUtility.HasFlagUnsafe(hInput.m_eButtonDown, hLockInput.m_eLockButton))
                {
                    hCursor.m_eLockMode = CursorLockMode.Locked;
                }
                else if (FlagUtility.HasFlagUnsafe(hInput.m_eButtonDown, hLockInput.m_eUnlockButton))
                {
                    hCursor.m_eLockMode = CursorLockMode.None;
                }

            }).ScheduleParallel();
        }
    }
}