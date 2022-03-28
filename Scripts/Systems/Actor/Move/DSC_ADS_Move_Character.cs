using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{    
    [UpdateInGroup(typeof(DSC_ADG_Move))]
    [UpdateAfter(typeof(DSC_ADS_FPS_Move))]
    public sealed partial class DSC_ADS_Move_Character : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDelTaTime = Time.DeltaTime;

            Entities.ForEach((CharacterController hCharacter
                , ref DSC_ADD_Move hMove) =>
            {
                hMove.m_fDeltaTimePrevious = fDelTaTime;

                if (hCharacter == null
                || !hMove.m_bHasMove)
                {
                    hMove.m_f3MovePrevious = float3.zero;
                    return;
                }


                hCharacter.Move(hMove.m_f3Move);

                hMove.m_bHasMove = false;
                hMove.m_f3MovePrevious = hMove.m_f3Move;
                hMove.m_f3Move = float3.zero;
            }).WithoutBurst()
            .Run();
        }
    }
}