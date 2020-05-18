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

            var hAnim = m_hAnim != null ? m_hAnim : m_hGameObject.GetComponent<Animator>();
            var hAudio = m_hAudio != null ? m_hAudio : m_hGameObject.GetComponent<AudioSource>();

            dstManager.AddComponentObject(entity, new DSC_ADM_GameObject
            {
                hGameObject = m_hGameObject,
                hTransform = m_hGameObject.transform,
                hRigid = m_hGameObject.GetComponent<Rigidbody>(),
                hRigid2D = m_hGameObject.GetComponent<Rigidbody2D>(),
                hAnim = hAnim,
                hAudio = hAudio
            });
        }
    }
}