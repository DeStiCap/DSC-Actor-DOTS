﻿using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(DSC_ADG_FixedUpdate_Late))]
    public sealed class DSC_ADG_Move : ComponentSystemGroup
    {

    }
}