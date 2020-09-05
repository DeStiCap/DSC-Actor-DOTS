using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(DSC_ADG_FixedUpdate_Normal))]
    public sealed class DSC_ADG_FixedUpdate_Early : ComponentSystemGroup
    {

    }
}