using UnityEngine;
using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early), OrderFirst = true)]
    [UpdateBefore(typeof(DSC_ADG_GameObjectToEntity))]
    public sealed partial class DSC_ADS_DestroyNullGameObject : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity hEntity
                ,in Transform transform) =>
            {
                if(transform == null)
                {
                    EntityManager.DestroyEntity(hEntity);
                }
            }).WithStructuralChanges()
            .Run();
        }
    }
}