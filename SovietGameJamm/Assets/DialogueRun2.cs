using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRun2 : MonoBehaviour
{
    public Dialogue Dialogue;
    public PlayerController2D PlayerController1;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        PlayerController1.enabled = false;
        PlayerController1.gameObject.GetComponent<Animator>().Play("Idle");
        DialogHelper.startd(Dialogue);
    }
}
