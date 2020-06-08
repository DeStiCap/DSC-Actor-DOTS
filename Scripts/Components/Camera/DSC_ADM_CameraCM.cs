using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [GenerateAuthoringComponent]
    public class DSC_ADM_CameraCM : IComponentData
    {
        public Transform transform;
    }
}