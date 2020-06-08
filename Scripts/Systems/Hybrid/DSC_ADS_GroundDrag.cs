using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADS_GroundCheck))]
    public sealed class DSC_ADS_GroundDrag : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Rigidbody hRigid
                ,ref DSC_ADD_GroundDrag hDrag
                ,ref DSC_ADD_GroundCheck hCheck) =>
            {
                if (hRigid == null || hCheck.m_bOnGroundPrevious == hCheck.m_bOnGround)
                    return;

                if (hCheck.m_bOnGround)
                {
                    hRigid.drag += hDrag.Value;
                }
                else
                {
                    hRigid.drag -= hDrag.Value;
                }


            }).WithoutBurst()
            .Run();
        }
    }
}