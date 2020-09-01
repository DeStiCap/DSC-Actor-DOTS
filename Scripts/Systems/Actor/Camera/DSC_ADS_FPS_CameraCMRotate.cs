using Unity.Entities;
using UnityEngine;

namespace DSC.Actor.DOTS
{
    [UpdateInGroup(typeof(DSC_ADG_Update_Normal))]
    public sealed class DSC_ADS_FPS_CameraCMRotate : SystemBase
    {
        protected override void OnUpdate()
        {
            float fDeltaTime = Time.DeltaTime;

            Entities.WithAll<DSC_ADT_FPS>()
                .ForEach((DSC_ADM_CameraCM hCamera
                , Transform transform
                , in DSC_ADD_CameraCMRotate hRotate
                , in DSC_ADD_Input hInput
                , in DSC_ADD_CursorLock hCursor) =>
            {
                if (transform == null || hCamera.transform == null
                || hCursor.m_eLockMode == CursorLockMode.None)
                    return;

                var f2Axis = hInput.m_hAxis2.m_f2RawAxis;

                var vChaRot = transform.localRotation;
                var vCamRot = hCamera.transform.localRotation;
                
                float fRotY = f2Axis.x * hRotate.m_fSensitiveX;
                float fRotX = f2Axis.y * hRotate.m_fSensitiveY;

                vChaRot *= Quaternion.Euler(0, fRotY, 0);
                vCamRot *= Quaternion.Euler(-fRotX, 0, 0);

                if (hRotate.m_bClampVertical)
                {

                    vCamRot.x /= vCamRot.w;
                    vCamRot.y /= vCamRot.w;
                    vCamRot.z /= vCamRot.w;
                    vCamRot.w = 1.0f;

                    float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(vCamRot.x);

                    angleX = Mathf.Clamp(angleX, hRotate.m_fVerticalMin, hRotate.m_fVerticalMax);

                    vCamRot.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
                }

                if (hRotate.m_bSmooth)
                {
                    float fSmooth = hRotate.m_fSmoothTime * fDeltaTime;
                    vChaRot = Quaternion.Slerp(transform.localRotation, vChaRot, fSmooth);
                    vCamRot = Quaternion.Slerp(hCamera.transform.localRotation, vCamRot, fSmooth);
                }

                transform.localRotation = vChaRot;
                hCamera.transform.localRotation = vCamRot;

            }).WithoutBurst()
            .Run();
        }
    }
}