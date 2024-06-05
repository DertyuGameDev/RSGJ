using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartDialogueScript : MonoBehaviour
{
    public static Action EndOfDialogue;
    public GameObject dialogueObject;
    public GameObject press;
    public Dialogue dialogue;
    public Controls control;
    public PlayerController2D playerController;
    public string cutscene;
    private void Awake()
    {
        control = new Controls();
        EndOfDialogue += EndOfD;
    }
    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
    public void OnTriggerEnter(Collider other)
    {
        press.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<BoxCollider>().enabled = false;
            press.SetActive(false);
            playerController.gameObject.GetComponent<Animator>().Play("New State");
            playerController.enabled = false;
            if (cutscene != "")
            {
                CutsceneManager.Instance.StartCutscene(cutscene);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        press.SetActive(false);
    }
    public void StartOfDialog()
    {
        dialogueObject.SetActive(true);
        DialogHelper.startd(dialogue);
    }
    public void EndOfD()
    {
        playerController.enabled = true;
        CutsceneManager.Instance.EndCutscene();
    }
}
