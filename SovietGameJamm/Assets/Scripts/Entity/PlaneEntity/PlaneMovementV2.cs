using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public TMP_Text erp;
    public TMP_Text rotT;
    public TMP_Text pos;
    public Scrollbar scrol;
    public Transform posit;
    public Transform negat;
    public Color On;
    public Color Off;
    public AudioSource aud;
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
        scrol.size = zavod / 100;
        if (driverIsOn)
        {
            aud.enabled = true;
            scrol.gameObject.GetComponent<Image>().color =  On;
        }
        else
        {
            aud.enabled = false;
            scrol.gameObject.GetComponent<Image>().color = Off;
        }
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
            zavod += 5;
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
            zavod += 5;
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

        erp.text = $"{this.transform.position.y:0.##}m  ";
        rotT.text = $"{this.transform.eulerAngles.y:0.#}°";
        pos.text = $"R: {roll:0.##}  P: {pitch:0.##}";

        if (transform.position.x > posit.position.x) {
            transform.position = new Vector3(negat.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.z > posit.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, negat.position.z);
        }

        if (transform.position.x < negat.position.x)
        {
            transform.position = new Vector3(posit.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.z < negat.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, posit.position.z);
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
