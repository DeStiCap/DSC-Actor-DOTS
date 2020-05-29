using DSC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace DSC.Actor.DOTS
{
    [RequireComponent(typeof(PlayerInput))]
    public class DSC_Actor_Input : MonoBehaviour
    {
        #region Variable

        PlayerInput m_hInput;

        int m_nPlayerID;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hInput = GetComponent<PlayerInput>();
            m_nPlayerID = m_hInput.playerIndex;
        }

        #endregion

        #region Events

        public void OnAxis(CallbackContext hValue)
        {
            DSC_Input.SetRawAxis(m_nPlayerID, hValue.ReadValue<Vector2>());
        }

        public void OnAxis2(CallbackContext hValue)
        {
            DSC_Input.SetRawAxis(m_nPlayerID, 1, hValue.ReadValue<Vector2>());
        }

        public void OnDPadUp(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.DPadUp, hValue.ReadValueAsButton());
        }

        public void OnDPadDown(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.DPadDown, hValue.ReadValueAsButton());
        }

        public void OnDPadLeft(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.DPadLeft, hValue.ReadValueAsButton());
        }

        public void OnDPadRight(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.DPadRight, hValue.ReadValueAsButton());
        }

        public void OnNorth(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.North, hValue.ReadValueAsButton());
        }

        public void OnSouth(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.South, hValue.ReadValueAsButton());
        }

        public void OnWest(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.West, hValue.ReadValueAsButton());
        }

        public void OnEast(CallbackContext hValue)
        {
            DSC_Input.SetButtonInput(m_nPlayerID, (int)InputButtonType.East, hValue.ReadValueAsButton());
        }

        #endregion
    }
}