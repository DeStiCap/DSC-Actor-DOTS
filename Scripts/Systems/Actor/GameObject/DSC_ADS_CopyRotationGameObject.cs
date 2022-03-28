using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_GameObjectToEntity))]
    public sealed partial class DSC_ADS_CopyRotationGameObject : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyRotation>()
                .ForEach((Transform transform
                ,ref Rotation hRot) =>
            {
                if (transform)
                {
                    hRot.Value = transform.rotation;
                }
            }).WithoutBurst()
            .Run();
        }
    }
}