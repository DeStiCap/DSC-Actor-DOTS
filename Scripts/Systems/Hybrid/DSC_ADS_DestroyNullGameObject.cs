using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public sealed class DSC_ADS_DestroyNullGameObject : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity hEntity
                ,DSC_ADM_GameObject hGameObjectData) =>
            {
                if(hGameObjectData.hGameObject == null)
                {
                    EntityManager.DestroyEntity(hEntity);
                }
            });
        }
    }
}