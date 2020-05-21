using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public sealed class DSC_ADS_CopyPositionGameObject : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyPosition>()
                .WithAll<DSC_ADT_GameObjectToEntity>()
                .ForEach((DSC_ADM_GameObject hGameObjectData
                ,ref Translation hTrans) =>
            {
                if (hGameObjectData.hTransform)
                {
                    hTrans.Value = hGameObjectData.hTransform.position;
                }
            });
        }
    }
}