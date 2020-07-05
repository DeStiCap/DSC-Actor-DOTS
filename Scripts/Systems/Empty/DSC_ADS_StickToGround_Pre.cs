using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(DSC_ADS_GroundCheck))]
    [UpdateAfter(typeof(DSC_ADS_GroundDrag))]
    [UpdateBefore(typeof(DSC_ADS_StickToGround))]
    public sealed class DSC_ADS_StickToGround_Pre : SystemBase
    {
        protected override void OnUpdate()
        {

        }
    }
}