using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateAfter(typeof(DSC_ADG_Update_Normal))]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public sealed class DSC_ADG_Update_PostNormal : ComponentSystemGroup
    {

    }
}