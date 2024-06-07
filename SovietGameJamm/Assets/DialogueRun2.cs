using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRun2 : MonoBehaviour
{
    public Dialogue Dialogue;
    public PlayerController2D PlayerController;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        PlayerController.enabled = false;
        PlayerController.gameObject.GetComponent<Animator>().Play("Idle");
        DialogHelper.startd(Dialogue);
    }
}
