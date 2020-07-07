using Unity.Entities;
using UnityEngine;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADS_GroundCheck))]
    public sealed class DSC_ADS_Jump : SystemBase
    {
        protected override void OnUpdate()
        {
            var fTime = Time.ElapsedTime;

            Entities.ForEach((Transform transform
                ,Rigidbody hRigid
                ,ref DSC_ADD_Input hInput
                ,ref DSC_ADD_Jump hJump
                ,ref DSC_ADD_GroundCheck hGround) =>
            {
                if (transform == null || hRigid == null
                || !hGround.m_bOnGround)
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
                    hRigid.AddForce(transform.up * hJump.m_fForce, ForceMode.Impulse);
                    hJump.m_bJumping = true;
                    hJump.m_fJumpStartTime = fTime;
                }               
                

            }).WithoutBurst()
            .Run();
        }
    }
}