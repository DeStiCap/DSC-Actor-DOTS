using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateAfter(typeof(DSC_ADS_Move_Pre))]
    [UpdateBefore(typeof(DSC_ADS_Move))]
    public sealed class DSC_ADS_Move_Character : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((CharacterController hCharacter
                , ref DSC_ADD_Move hMove) =>
            {
                if (hCharacter == null
                || !hMove.m_bHasMove)
                    return;

                hCharacter.Move(hMove.m_f3Move);

                hMove.m_bHasMove = false;
                hMove.m_f3Move = float3.zero;
            }).WithoutBurst()
            .Run();
        }
    }
}