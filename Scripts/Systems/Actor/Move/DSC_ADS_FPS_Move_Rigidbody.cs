using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{    
    [UpdateInGroup(typeof(DSC_ADG_Move))]
    [UpdateAfter(typeof(DSC_ADS_FPS_Move))]
    public sealed partial class DSC_ADS_FPS_Move_Rigidbody : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDeltaTime = Time.DeltaTime;

            var vCamForward = Camera.main.transform.forward;
            var vCamRight = Camera.main.transform.right;

            Entities.WithAll<DSC_ADT_FPS>()
                .ForEach((Rigidbody hRigid
                , ref DSC_ADD_Move hMove) =>
            {
                if (hRigid == null
                || !hMove.m_bHasMove)
                    return;

                hRigid.MovePosition(hRigid.position + (Vector3)hMove.m_f3Move);

                hMove.m_bHasMove = false;
                hMove.m_f3Move = float3.zero;

            }).WithNone<CharacterController>()
            .WithoutBurst()
            .Run();
        }
    }
}