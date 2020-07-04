using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public class DSC_ADM_MoveSlopeCurve : IComponentData
    {
        public AnimationCurve Value;
    }
}