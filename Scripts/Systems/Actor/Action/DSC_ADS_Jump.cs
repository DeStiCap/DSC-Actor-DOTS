using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_FixedUpdate_Early))]
    [UpdateAfter(typeof(DSC_ADG_GroundCheck))]
    public sealed class DSC_ADS_Jump : SystemBase
    {
        protected override void OnUpdate()
        {
            var fTime = Time.ElapsedTime;

            Entities.ForEach((ref DSC_ADD_Input hInput
                , ref DSC_ADD_Jump hJump                
                , ref DSC_ADD_Velocity hVelocity
                , in DSC_ADD_GroundCheck hGround) =>
            {
                if (!hGround.m_bOnGround)
                    goto Finish;

                if (hJump.m_bJumping)
                {
                    if (hGround.m_bOnGround
                    && (!hGround.m_bOnGroundPrevious || (fTime >= hJump.m_fJumpStartTime + 0.2f)))
                        hJump.m_bJumping = false;
                    else
                        goto Finish;
                }

                if (hJump.m_bJumpInput)
                {
                    hVelocity.m_f3Velocity.y += hJump.m_fForce;
                    hJump.m_bJumping = true;
                    hJump.m_fJumpStartTime = fTime;
                }

            Finish:
                hJump.m_bJumpInput = false;

            }).ScheduleParallel();
        }
    }
}