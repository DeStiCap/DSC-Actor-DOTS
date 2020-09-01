using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    [UpdateBefore(typeof(DSC_ADG_Update_Late))]
    public sealed class DSC_ADG_Update_PreLate : ComponentSystemGroup
    {

    }
}