using DSC.Core;
using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early))]
    [UpdateAfter(typeof(DSC_ADS_Input))]
    public sealed partial class DSC_ADS_JumpInput : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_Jump hJump
                , in DSC_ADD_Input hInput) =>
            {
                if (hJump.m_bJumpInput)
                    return;

                if (FlagUtility.HasFlagUnsafe(hInput.m_eButtonDown, hJump.m_eButton))
                {
                    hJump.m_bJumpInput = true;
                }

            }).ScheduleParallel();
        }
    }
}