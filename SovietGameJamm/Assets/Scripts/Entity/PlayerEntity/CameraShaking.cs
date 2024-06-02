using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] bool enable;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform playerCameraPivot;

    [SerializeField, Range(0, 0.1f)] float amplitude;
    [SerializeField, Range(0, 30)] float frequency;

    [SerializeField] float toggleSpeed;
    Vector3 startPos;
    Vector3 lastPosition;
    CharacterController playerController;

    bool isMoving;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        startPos = playerCamera.localPosition;
    }

    private void Update()
    {
        if (lastPosition.x != transform.position.x && lastPosition.z != transform.position.z) { isMoving = true; }
        else { isMoving = false; }

        if (!enable) { return; }

        CheckMotion();
        ResetPosition();
        playerCamera.LookAt(FocusTarget());

        lastPosition = transform.position;
    }

    private void PlayMotion(Vector3 motion)
    {
        playerCamera.localPosition += motion;
    }

    private void ResetPosition() 
    {
        if (playerCamera.localPosition == startPos) { return; }
        playerCamera.localPosition = Vector3.Lerp(playerCamera.localPosition, startPos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + playerCameraPivot.localPosition.y, transform.position.z);
        pos += playerCameraPivot.forward * 15.0f;
        return pos;
    }

    private void CheckMotion()
    {
        if (!isMoving) { return; }
        if (!playerController.isGrounded) { return; }

        PlayMotion(FootStepMotion());
    }


    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }
}
