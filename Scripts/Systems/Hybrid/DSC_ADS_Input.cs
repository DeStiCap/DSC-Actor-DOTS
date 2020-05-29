using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using DSC.Core;

namespace DSC.Actor.DOTS
{
    public sealed class DSC_ADS_Input : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref DSC_ADD_Player hPlayer
                ,ref DSC_ADD_Input hInput) =>
            {
                int nPlayerID = hPlayer.m_nID;

                var hAxis = hInput.m_hAxis;
                hAxis.m_f2RawAxis = DSC_Input.GetRawAxis(nPlayerID);
                hAxis.m_f2Axis = DSC_Input.GetAxis(nPlayerID);
                hAxis.m_eHorizontalPress = DSC_Input.GetHorizontalPress(nPlayerID);
                hAxis.m_eHorizontalDoublePress = DSC_Input.GetHorizontalDoublePress(nPlayerID);
                hAxis.m_eHorizontalTap = DSC_Input.GetHorizontalTap(nPlayerID);
                hAxis.m_eHorizontalDoubleTap = DSC_Input.GetHorizontalDoubleTap(nPlayerID);
                hAxis.m_eVerticalPress = DSC_Input.GetVerticalPress(nPlayerID);
                hAxis.m_eVerticalDoublePress = DSC_Input.GetVerticalDoublePress(nPlayerID);
                hAxis.m_eVerticalTap = DSC_Input.GetVerticalTap(nPlayerID);
                hAxis.m_eVerticalDoubleTap = DSC_Input.GetVerticalDoubleTap(nPlayerID);             

                var hAxis2 = hInput.m_hAxis2;
                hAxis2.m_f2RawAxis = DSC_Input.GetRawAxis(nPlayerID, 1);
                hAxis2.m_f2Axis = DSC_Input.GetAxis(nPlayerID, 1);
                hAxis2.m_eHorizontalPress = DSC_Input.GetHorizontalPress(nPlayerID, 1);
                hAxis2.m_eHorizontalDoublePress = DSC_Input.GetHorizontalDoublePress(nPlayerID, 1);
                hAxis2.m_eHorizontalTap = DSC_Input.GetHorizontalTap(nPlayerID, 1);
                hAxis2.m_eHorizontalDoubleTap = DSC_Input.GetHorizontalDoubleTap(nPlayerID, 1);
                hAxis2.m_eVerticalPress = DSC_Input.GetVerticalPress(nPlayerID, 1);
                hAxis2.m_eVerticalDoublePress = DSC_Input.GetVerticalDoublePress(nPlayerID, 1);
                hAxis2.m_eVerticalTap = DSC_Input.GetVerticalTap(nPlayerID, 1);
                hAxis2.m_eVerticalDoubleTap = DSC_Input.GetVerticalDoubleTap(nPlayerID, 1);

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