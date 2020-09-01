using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early))]
    [UpdateAfter(typeof(DSC_ADG_GroundCheck))]
    public sealed class DSC_ADS_GroundDrag : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Rigidbody hRigid
                ,in DSC_ADD_GroundDrag hDrag
                ,in DSC_ADD_GroundCheck hCheck) =>
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