using Unity.Entities;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_FixedUpdate_Normal))]
    public sealed class DSC_ADS_CurrentMoveSpeed3DByInput : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_MoveSpeed3D hSpeed
                , in DSC_ADD_Input hInput) =>
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