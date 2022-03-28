using Unity.Entities;
using DSC.Core;
using DSC.Input;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Early))]
    public sealed partial class DSC_ADS_Input : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_Input hInput
                , in DSC_ADD_Player hPlayer) =>
            {
                int nPlayerID = hPlayer.m_nID;

                var hAxis = hInput.m_hAxis;
                hAxis.m_f2RawAxis = DSC_Input.GetRawAxis(nPlayerID);
                hAxis.m_f2Axis = DSC_Input.GetAxis(nPlayerID);
                hAxis.m_eAxisPress = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.Press);
                hAxis.m_eAxisDoublePress = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.DoublePress);
                hAxis.m_eAxisTap = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.Tap);
                hAxis.m_eAxisDoubleTap = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.DoubleTap);


                var hAxis2 = hInput.m_hAxis2;
                hAxis2.m_f2RawAxis = DSC_Input.GetRawAxis(nPlayerID, 1);
                hAxis2.m_f2Axis = DSC_Input.GetAxis(nPlayerID, 1);
                hAxis2.m_eAxisPress = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.Press, 1);
                hAxis2.m_eAxisDoublePress = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.DoublePress, 1);
                hAxis2.m_eAxisTap = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.Tap, 1);
                hAxis2.m_eAxisDoubleTap = DSC_Input.GetAxisEvent(nPlayerID, AxisEventType.DoubleTap, 1);


                var eDown = (InputButtonType)DSC_Input.GetAllButtonDownFlag(nPlayerID);
                var eHold = (InputButtonType)DSC_Input.GetAllButtonHoldFlag(nPlayerID);
                var eUp = (InputButtonType)DSC_Input.GetAllButtonUpFlag(nPlayerID);

                hInput.m_hAxis = hAxis;
                hInput.m_hAxis2 = hAxis2;
                hInput.m_eButtonDown = eDown;
                hInput.m_eButtonHold = eHold;
                hInput.m_eButtonUp = eUp;
            }).WithoutBurst()
            .Run();
        }
    }
}