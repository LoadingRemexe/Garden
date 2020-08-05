using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Transform cameraTransform = null;
    private Vector2 inputVect = Vector2.zero;
    float smoothTime = 10f;
    Quaternion CharacterTargetRot = Quaternion.identity;
    Quaternion CameraTargetRot = Quaternion.identity;

    private void Start()
    {
        CharacterTargetRot = transform.localRotation;
        CameraTargetRot = cameraTransform.localRotation;
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputVect = context.ReadValue<Vector2>();
        CharacterTargetRot = transform.localRotation;
        CameraTargetRot = cameraTransform.localRotation;
    }

    private void FixedUpdate()
    {
        LookRotation();
    }

    public void LookRotation()
    {
        CharacterTargetRot *= Quaternion.Euler(0f, inputVect.x, 0f);
        CameraTargetRot *= Quaternion.Euler(-inputVect.y, 0f, 0f);
        CameraTargetRot = ClampRotationAroundXAxis(CameraTargetRot);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, CharacterTargetRot, smoothTime * Time.deltaTime);
        cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, CameraTargetRot, smoothTime * Time.deltaTime);
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -90, 90);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

}
