using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] Vector2 rotationRange;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float dampingTime = 0.2f;
    Vector3 targetAngles;
    Vector3 followAngles;
    Vector3 followVelocity;
    Quaternion originalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalRotation = transform.localRotation;
    }

    private void Update()
    {
        transform.localRotation = originalRotation;

        float inputH = Input.GetAxis("Mouse X");
        float inputV = Input.GetAxis("Mouse Y");

        targetAngles.y += inputH * rotationSpeed;
        targetAngles.x += inputV * rotationSpeed;

        targetAngles.y = Mathf.Clamp(targetAngles.y, -rotationRange.y * 0.5f, rotationRange.y * 0.5f);
        targetAngles.x = Mathf.Clamp(targetAngles.x, -rotationRange.x * 0.5f, rotationRange.x * 0.5f);

        followAngles = Vector3.SmoothDamp(followAngles, targetAngles, ref followVelocity, dampingTime);

        transform.localRotation = originalRotation * Quaternion.Euler(-followAngles.x, followAngles.y, 0);
    }
}

