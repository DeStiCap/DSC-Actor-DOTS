using UnityEngine;
using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public sealed class DSC_ADS_DestroyNullGameObject : ComponentSystem
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
            });
        }
    }
}