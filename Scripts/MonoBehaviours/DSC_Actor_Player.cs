using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    public class DSC_Actor_Player : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [Min(0)]
        [SerializeField] int m_nPlayerID;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public int playerID { get { return m_nPlayerID; } }

        #endregion

        #endregion

        #region Main

        public void SetPlayerID(int nID)
        {
            if(nID < 0)
            {
                Debug.LogError("Can't set player ID less then 0.",gameObject);
                return;
            }

            m_nPlayerID = nID;
        }

        #endregion
    }
}