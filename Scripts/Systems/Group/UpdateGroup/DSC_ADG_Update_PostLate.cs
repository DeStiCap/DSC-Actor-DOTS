using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    [UpdateAfter(typeof(DSC_ADG_Update_Late))]
    [UpdateBefore(typeof(LateSimulationSystemGroup))]
    public sealed class DSC_ADG_Update_PostLate : ComponentSystemGroup
    {

    }
}