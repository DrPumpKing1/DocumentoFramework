using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CinemachinePOVExtension : CinemachineExtension
{
    [Header("Camera Properties")] 
    [SerializeField] private float upperAngleLimit = 80f;
    [SerializeField] private float lowerAngleLimit = -70f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] private float sensibility;
    
    private Vector2 mouseDirection;
    private Vector3 startRotation;

    [Header("Extra Components")] 
    [SerializeField] private Transform orientation;

    protected override void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        base.Awake();
    }

    public void OnMouseMove(InputAction.CallbackContext ctx)
    {
        mouseDirection = ctx.ReadValue<Vector2>();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(!vcam.Follow) return;
        if(stage != CinemachineCore.Stage.Aim) return;

        if (startRotation == null) startRotation = transform.localRotation.eulerAngles;

        startRotation.x += mouseDirection.x * verticalSpeed * sensibility * Time.deltaTime;
        startRotation.y -= mouseDirection.y *  horizontalSpeed * sensibility * Time.deltaTime;
        startRotation.y = Mathf.Clamp(startRotation.y, lowerAngleLimit, upperAngleLimit);
        
        if(orientation != null) orientation.transform.rotation = Quaternion.Euler(0f, startRotation.x, 0f);
        state.RawOrientation = Quaternion.Euler(startRotation.y, startRotation.x, 0f);
    }
}
