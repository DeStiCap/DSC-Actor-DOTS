using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateBefore(typeof(DSC_ADS_Move_Pre))]
    public sealed class DSC_ADS_GravityCharacter : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDeltaTime = Time.DeltaTime;

            Entities.ForEach((Transform transform
                , CharacterController hCharacter
                , ref DSC_ADD_Gravity hGravity
                , ref DSC_ADD_Move hMove
                ,ref DSC_ADD_GroundCheck hGround) =>
            {
                if (hGround.m_bOnGround)
                    return;

                hMove.m_bHasMove = true;
                hMove.m_f3Move += (float3)(transform.up * hGravity.m_fGravity * fDeltaTime);

            }).WithoutBurst()
            .Run();
        }
    }
}