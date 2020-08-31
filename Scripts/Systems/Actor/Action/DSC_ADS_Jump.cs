using Unity.Entities;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early))]
    [UpdateAfter(typeof(DSC_ADG_GroundCheck))]
    public sealed class DSC_ADS_Jump : SystemBase
    {
        protected override void OnUpdate()
        {
            var fTime = Time.ElapsedTime;

            Entities.ForEach((ref DSC_ADD_Input hInput
                , ref DSC_ADD_Jump hJump
                , ref DSC_ADD_GroundCheck hGround
                , ref DSC_ADD_Velocity hVelocity) =>
            {
                if (!hGround.m_bOnGround)
                    return;

                if (hJump.m_bJumping)
                {
                    if (hGround.m_bOnGround
                    && (!hGround.m_bOnGroundPrevious || (fTime >= hJump.m_fJumpStartTime + 0.2f)))
                        hJump.m_bJumping = false;
                    else
                        return;
                }

                if (FlagUtility.HasFlagUnsafe(hInput.m_eButtonDown, hJump.m_eButton))
                {
                    hVelocity.m_f3Velocity.y += hJump.m_fForce;
                    hJump.m_bJumping = true;
                    hJump.m_fJumpStartTime = fTime;
                }


            }).ScheduleParallel();
        }
    }
}