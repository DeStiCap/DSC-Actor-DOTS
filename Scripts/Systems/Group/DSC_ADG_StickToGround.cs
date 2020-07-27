using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADG_GroundCheck))]
    [UpdateAfter(typeof(DSC_ADS_GroundDrag))]
    public sealed class DSC_ADG_StickToGround : ComponentSystemGroup
    {

    }
}