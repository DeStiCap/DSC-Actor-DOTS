using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateBefore(typeof(DSC_ADS_Move_Pre))]
    public sealed class DSC_ADS_CurrentMoveSpeed3DByInput : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_Input hInput
                ,ref DSC_ADD_MoveSpeed3D hSpeed) =>
            {
                var f2Axis = hInput.m_hAxis.m_f2Axis;
                float fCurrentTargetSpeed = 0;

                if (f2Axis.x != 0)
                {
                    fCurrentTargetSpeed = hSpeed.m_fStrafeSpeed;
                }

                if (f2Axis.y < 0)
                    fCurrentTargetSpeed = hSpeed.m_fBackwardSpeed;
                else if (f2Axis.y > 0)
                    fCurrentTargetSpeed = hSpeed.m_fForwardSpeed;

                hSpeed.m_fCurrentSpeed = fCurrentTargetSpeed;

            }).ScheduleParallel();
        }
    }
}