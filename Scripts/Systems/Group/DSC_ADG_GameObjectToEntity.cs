using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public sealed class DSC_ADG_GameObjectToEntity : ComponentSystemGroup
    {

    }
}