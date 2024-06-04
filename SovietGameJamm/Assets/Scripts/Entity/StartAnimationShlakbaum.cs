using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationShlakbaum : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void OnTriggerEnter(Collider other)
    {
        animator.Play("Close");
    }

    public void OnTriggerExit(Collider other)
    {
        animator.Play("Open");
    }
}
