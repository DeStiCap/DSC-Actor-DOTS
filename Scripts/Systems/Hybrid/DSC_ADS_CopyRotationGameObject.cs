using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public sealed class DSC_ADS_CopyRotationGameObject : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyRotation>()
                .WithAll<DSC_ADT_GameObjectToEntity>()
                .ForEach((DSC_ADM_GameObject hGameObjectData
                ,ref Rotation hRot) =>
            {
                if (hGameObjectData.hTransform)
                {
                    hRot.Value = hGameObjectData.hTransform.rotation;
                }
            });
        }
    }
}