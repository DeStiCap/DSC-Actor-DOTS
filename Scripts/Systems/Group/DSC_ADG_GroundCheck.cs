using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADG_GameObjectToEntity))]
    public sealed class DSC_ADG_GroundCheck : ComponentSystemGroup
    {

    }
}