using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_PostLate))]
    public sealed class DSC_ADS_Debug_Rigidbody_Velocity : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_Debug_Rigidbody_Velocity>()
                .ForEach((Rigidbody hRigid) =>
            {
                if (hRigid)
                {
                    Debug.Log("Velocity : " + hRigid.velocity,hRigid.gameObject);
                }
            }).WithoutBurst()
            .Run();
        }
    }
}