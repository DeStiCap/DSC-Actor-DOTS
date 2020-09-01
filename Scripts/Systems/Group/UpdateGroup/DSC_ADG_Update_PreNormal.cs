using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [ExecuteAlways]
    [UpdateBefore(typeof(DSC_ADG_Update_Normal))]
    public sealed class DSC_ADG_Update_PreNormal : ComponentSystemGroup
    {

    }
}