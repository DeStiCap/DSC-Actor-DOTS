﻿using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateInGroup(typeof(DSC_ADG_Update_Early), OrderFirst = true)]
    public sealed class DSC_ADG_GameObjectToEntity : ComponentSystemGroup
    {

    }
}