using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(DSC_ADG_FixedUpdate_Early))]
    [UpdateAfter(typeof(DSC_ADG_GroundCheck))]
    [UpdateAfter(typeof(DSC_ADS_GroundDrag))]
    public sealed class DSC_ADG_StickToGround : ComponentSystemGroup
    {

    }
}