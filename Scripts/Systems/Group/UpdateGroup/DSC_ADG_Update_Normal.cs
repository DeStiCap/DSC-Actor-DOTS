﻿using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateAfter(typeof(FixedStepSimulationSystemGroup))]
    public sealed class DSC_ADG_Update_Normal : ComponentSystemGroup
    {

    }
}