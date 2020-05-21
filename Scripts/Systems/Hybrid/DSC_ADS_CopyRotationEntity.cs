using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public sealed class DSC_ADS_CopyRotationEntity : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyRotation>()
                .WithAll<DSC_ADT_EntityToGameObject>()
                .ForEach((DSC_ADM_GameObject hGameObjectData
                ,ref Rotation hRot) =>
            {
                if (hGameObjectData.hTransform)
                {
                    hGameObjectData.hTransform.rotation = hRot.Value;
                }
            });
        }
    }
}