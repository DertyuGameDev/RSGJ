using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    [Header("Player Move")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;

    [Header("GroundCheck & Physics")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundMask;
    [SerializeField] public bool isGrounded;
    [SerializeField] float gravity;

    CharacterController controller;
    Vector3 Velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        move();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump();
        }
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero;

        move.x = x;
        move.z = z;

        controller.Move(transform.TransformDirection(move) * moveSpeed * Time.deltaTime);

        Velocity.y += gravity * Time.deltaTime;

        controller.Move(Velocity * Time.deltaTime);
    }

    void jump()
    {
        Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

}
