using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovementV2 : MonoBehaviour
{
    [SerializeField] float speedPlane = 0.1f;
    [SerializeField] float maxSpeed;
    [SerializeField] bool driverIsOn;
    [SerializeField] float speedRotationV = 10f;
    [SerializeField] float speedRotationH = 10f;
    public static bool onGround;
    public bool g;
    public Transform controler;
    private float roll;
    private float pitch;
    public float zavod;
    [Range(0f, 1f)]
    public float t;
    Rigidbody rb;
    private void Awake()
    {
        zavod = 0;
        driverIsOn = false;
        rb = GetComponent<Rigidbody>();
    }

    private void checkInputs() 
    {
        roll = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        g = onGround;
        if (speedPlane <= 0 && onGround)
        {
            GetComponent<Animator>().Play("Open");
        }
        else
        {
            GetComponent<Animator>().Play("Close");
        }
        checkInputs();
        Vector3 rot = new Vector3(pitch, 0, -roll);
        controler.localRotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(rot * 10), t);
        if (Input.GetKey(KeyCode.LeftShift) && driverIsOn == false)
        {
            zavod += 1;
            if (zavod > 100)
            {
                driverIsOn = true;
                zavod = 0;
            }
        }
        if (driverIsOn)
        {
            if (Input.GetKey(KeyCode.E))
            {
                speedPlane += 60;
            }
            else if (Input.GetKey(KeyCode.Q)) 
            {
                speedPlane -= 60;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl) && driverIsOn)
        {
            zavod += 1;
            if (zavod > 100)
            {
                driverIsOn = false;
                zavod = 0;
            }
        }
        if (!driverIsOn && speedPlane > 0) 
        {
            speedPlane -= 30;
        }
        if (speedPlane < 0)
        {
            speedPlane = 0;
        }
        if (speedPlane > maxSpeed)
        {
            speedPlane = maxSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * speedPlane);
        if (!onGround)
        {
            rb.AddTorque(transform.forward * -roll * speedRotationH * speedPlane / 1000);
            rb.AddTorque(transform.right * pitch * speedRotationV * speedPlane / 1000);
        }
        else
        {
            rb.AddTorque(transform.forward * -roll * speedRotationH);
            rb.AddTorque(transform.right * pitch * speedRotationV);
        }
    }
}
