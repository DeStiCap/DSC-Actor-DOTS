﻿using Unity.Entities;
using Unity.Transforms;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public sealed class DSC_ADS_CopyPositionEntity : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<DSC_ADT_CopyPosition>()
                .WithAll<DSC_ADT_EntityToGameObject>()
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