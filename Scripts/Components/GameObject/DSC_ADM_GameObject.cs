using UnityEngine;
using Unity.Entities;

namespace DSC.Actor.DOTS
{
    public class DSC_ADM_GameObject : IComponentData
    {
        public GameObject hGameObject;
        public Transform hTransform;        
        public Rigidbody hRigid;
        public Rigidbody2D hRigid2D;
        public Animator hAnim;
        public AudioSource hAudio;
    }
}