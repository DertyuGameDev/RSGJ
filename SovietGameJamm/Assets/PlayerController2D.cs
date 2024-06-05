using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform RaycastGameobject;
    public Controls controls;
    public float distanceToDirty;
    [Header("WalkSpeed")]
    public float walkSpeed;
    public float maxSpeed;
    [Header("Jump")]
    [SerializeField] private bool isGround;
    public float jumpForce;
    public float cooldownJump;
    public bool canJump;
    [SerializeField] LayerMask Ground;

    private void Awake()
    {
        controls = new Controls();

        controls.Main.Jump.performed += context => Jump();
    }
    private void Update()
    {
        isGround = CheckGround();
        LimitVelocity();
        Move();
    }
    private void Move()
    {
        float move = controls.Main.Move.ReadValue<float>();
        switch (move)
        {
            case -1:
                GetComponent<SpriteRenderer>().flipX = true; break;
            case 1:
                GetComponent<SpriteRenderer>().flipX = false; break;
        }
        Vector3 moveDir = new Vector3(-move, 0, 0);
        if (moveDir != Vector3.zero)
        {
            GetComponent<Animator>().Play("Walk");
        }
        else
        {
            GetComponent<Animator>().Play("Idle");
        }
        rb.velocity += moveDir * walkSpeed;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    #region JUMP
    public void Jump()
    {
        if (CheckGround() && canJump)
        {
            canJump = false;
            Invoke("ResetJump", cooldownJump);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    void ResetJump()
    {
        canJump = true;
    }
    public bool CheckGround()
    {
        Ray r = new Ray(RaycastGameobject.position, Vector3.down);
        return Physics.Raycast(r, distanceToDirty, Ground);
    }
    #endregion
    private void LimitVelocity()
    {
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            Vector3 move = new Vector3(rb.velocity.x, 0, 0);
            move.Normalize();
            rb.velocity = new Vector3(maxSpeed * move.x, rb.velocity.y, rb.velocity.z);
        }
    }
    private void OnDrawGizmos()
    {
        Ray r = new Ray(RaycastGameobject.position, Vector3.down);
        Gizmos.DrawRay(r);
    }
}
