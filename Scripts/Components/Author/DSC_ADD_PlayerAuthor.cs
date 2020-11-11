using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    public class DSC_ADD_PlayerAuthor : MonoBehaviour, IConvertGameObjectToEntity
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DSC_Actor_Player m_hPlayer;

#pragma warning restore 0649
        #endregion

        #endregion


        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            if(m_hPlayer == null && transform.parent != null)
            {
                m_hPlayer = transform.parent.GetComponent<DSC_Actor_Player>();
            }

            if(m_hPlayer == null)
            {
                Debug.LogError("Need to assign DSC_Actor_Player.");
                return;
            }

            dstManager.AddComponentData(entity, new DSC_ADD_Player
            {
                m_nID = m_hPlayer.playerID
            });
        }
    }
}