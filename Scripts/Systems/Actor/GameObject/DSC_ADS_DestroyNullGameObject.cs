using UnityEngine;
using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early), OrderFirst = true)]
    [UpdateBefore(typeof(DSC_ADG_GameObjectToEntity))]
    public sealed class DSC_ADS_DestroyNullGameObject : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity hEntity
                ,Transform transform) =>
            {
                if(transform == null)
                {
                    EntityManager.DestroyEntity(hEntity);
                }
            }).WithoutBurst()
            .Run();
        }
    }
}