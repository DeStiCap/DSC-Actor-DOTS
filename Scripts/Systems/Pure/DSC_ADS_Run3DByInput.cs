﻿using Unity.Entities;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [UpdateBefore(typeof(DSC_ADS_Move_Pre))]
    [UpdateAfter(typeof(DSC_ADS_CurrentMoveSpeed3DByInput))]
    public sealed class DSC_ADS_Run3DByInput : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_Run hRun
                ,ref DSC_ADD_Input hInput
                ,ref DSC_ADD_MoveSpeed3D hSpeed) =>
            {
                switch (hRun.m_eInputType)
                {
                    case GetInputType.Down:
                        if (FlagUtility.HasFlagUnsafe(hInput.m_eButtonDown, hRun.m_eButton))
                        {
                            hRun.m_bRunning = !hRun.m_bRunning;
                        }
                        break;

                    case GetInputType.Hold:
                        hRun.m_bRunning = FlagUtility.HasFlagUnsafe(hInput.m_eButtonHold, hRun.m_eButton);
                        break;

                    case GetInputType.Up:
                        if (FlagUtility.HasFlagUnsafe(hInput.m_eButtonUp, hRun.m_eButton))
                        {
                            hRun.m_bRunning = !hRun.m_bRunning;
                        }
                        break;
                }

                if (hRun.m_bRunning)
                {
                    hSpeed.m_fCurrentSpeed *= hRun.m_fSpeedMultiplier;
                }

            }).ScheduleParallel();
        }
    }
}