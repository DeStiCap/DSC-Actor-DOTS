using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public sealed class DSC_ADS_MoveGameObject : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((DSC_ADM_GameObject hGameObjectData
                ,ref DSC_ADD_Move hMoveData
                ,ref DSC_ADD_MoveGameObjectType hCopyType
                ,ref DSC_ADD_RigidbodyType hRigidType) =>
            {
                if (!hMoveData.bHasMove)
                    return;

                Vector3 vMove = hMoveData.f3Move;

                switch (hCopyType.Value)
                {
                    case MoveGameObjectType.Transform:
                        if (hGameObjectData.hTransform)
                        {
                            hGameObjectData.hTransform.position += vMove;
                        }
                        break;

                    case MoveGameObjectType.Rigidbody:
                        if(hRigidType.Value == RigidbodyType.Rigidbody3D
                        && hGameObjectData.hRigid)
                        {
                            hGameObjectData.hRigid.MovePosition(hGameObjectData.hRigid.position + vMove);
                        }
                        else if(hGameObjectData.hRigid2D)
                        {
                            hGameObjectData.hRigid2D.MovePosition(hGameObjectData.hRigid2D.position + (Vector2)vMove);
                        }

                        break;
                }

                hMoveData.bHasMove = false;
                hMoveData.f3Move = float3.zero;
            });
        }
    }
}