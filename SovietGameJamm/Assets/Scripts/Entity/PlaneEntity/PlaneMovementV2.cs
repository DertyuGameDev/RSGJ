using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovementV2 : MonoBehaviour
{
    [SerializeField] float throttleIncrement = 0.1f;
    
    [SerializeField] float maxThrust = 200f;

    [SerializeField] float responsivness = 10f;

    private float throttle;
    private float roll;
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
    }

    private void checkInputs() 
    {
        roll = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Mouse Y");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle += throttleIncrement;
        throttle = Mathf.Clamp(throttle, 20f, 100f);
    }

    private void Update()
    {
        checkInputs();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responsivness);
        rb.AddTorque(transform.right * pitch * responsivness);
        rb.AddTorque(-transform.forward * roll * responsivness);
    }
}
