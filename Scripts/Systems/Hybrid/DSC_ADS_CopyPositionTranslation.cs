using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public sealed class DSC_ADS_CopyPositionTranslation : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyPositionTranslation>()
                .ForEach((DSC_ADM_GameObject hGameObjectData
                ,ref Translation hTrans) =>
            {
                if (hGameObjectData.hTransform)
                {
                    hGameObjectData.hTransform.position = hTrans.Value;
                }
            });
        }
    }
}