﻿using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateBefore(typeof(DSC_ADS_Move))]
    public sealed class DSC_ADS_Move_Pre : SystemBase
    {
        protected override void OnUpdate()
        {
            
        }
    }
}