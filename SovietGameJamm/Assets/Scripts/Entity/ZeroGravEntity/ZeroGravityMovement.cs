using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityMovement : MonoBehaviour
{
    [SerializeField] float throttleIncrement = 0.1f;
    [SerializeField] float minThrottle = 10f;
    [SerializeField] float maxThrottle = -10f;

    [SerializeField] float maxThrust = 200f;

    [SerializeField] float responsivness = 10f;
    [SerializeField] float pitchModifier = 10f;
    [SerializeField] float yawModifier = 4f;

    [SerializeField] private float throttle;
    private float rollY;
    private float pitch;
    private float yaw;

    Rigidbody rb;

    private float responseModifier()
    {
        return (rb.mass / 10f) * responsivness;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void checkInputs() 
    {
        yaw = Input.GetAxis("Yaw");
        pitch = Input.GetAxis("Mouse Y");
        rollY = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.S)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, minThrottle, maxThrottle);
    }

    private void Update()
    {
        checkInputs();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * rollY * responsivness * yawModifier);
        rb.AddTorque(transform.right * pitch * responsivness * pitchModifier);
        rb.AddTorque(-transform.forward * yaw * responsivness * yawModifier);
    }
}
