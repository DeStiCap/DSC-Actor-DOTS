using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(DSC_ADG_FixedUpdate_Early))]
    public sealed class DSC_ADG_GroundCheck : ComponentSystemGroup
    {

    }
}