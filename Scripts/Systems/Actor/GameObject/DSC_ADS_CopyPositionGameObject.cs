using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_GameObjectToEntity))]
    public sealed partial class DSC_ADS_CopyPositionGameObject : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyPosition>()
                .ForEach((Transform transform
                ,ref Translation hTrans) =>
            {
                if (transform)
                {
                    hTrans.Value = transform.position;
                }
            }).WithoutBurst()
            .Run();
        }
    }
}