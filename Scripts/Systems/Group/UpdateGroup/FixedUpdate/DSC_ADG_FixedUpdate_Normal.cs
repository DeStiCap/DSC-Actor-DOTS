using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public sealed class DSC_ADG_FixedUpdate_Normal : ComponentSystemGroup
    {

    }
}