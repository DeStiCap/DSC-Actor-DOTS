using UnityEngine;
using Unity.Entities;

namespace DSC.Actor.DOTS
{
    public class DSC_ADM_GameObjectAuthor : MonoBehaviour, IConvertGameObjectToEntity
    {
        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] GameObject m_hGameObject;
        [SerializeField] Animator m_hAnim;
        [SerializeField] AudioSource m_hAudio;

#pragma warning restore 0649
        #endregion

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            if (m_hGameObject == null)
            {
                Debug.LogError("Need to assign GameObject.",gameObject);
                return;
            }

            dstManager.AddComponentObject(entity, m_hGameObject.transform);

            
            if (m_hAnim)
                dstManager.AddComponentObject(entity, m_hAnim);

            if (m_hAudio)
                dstManager.AddComponentObject(entity, m_hAudio);

            var hRigid = m_hGameObject.GetComponent<Rigidbody>();
            if (hRigid)
                dstManager.AddComponentObject(entity, hRigid);

            var hRigid2D = m_hGameObject.GetComponent<Rigidbody2D>();
            if (hRigid2D)
                dstManager.AddComponentObject(entity, hRigid2D);


            var hCapsule = m_hGameObject.GetComponent<CapsuleCollider>();
            if (hCapsule)
                dstManager.AddComponentObject(entity, hCapsule);
        }
    }
}