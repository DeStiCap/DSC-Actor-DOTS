using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    [UpdateAfter(typeof(DSC_ADG_Update_Early))]
    [UpdateBefore(typeof(FixedStepSimulationSystemGroup))]
    public sealed class DSC_ADG_Update_PostEarly : ComponentSystemGroup
    {

    }
}