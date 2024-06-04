using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InteractiveObject;

public class InteractManager : MonoBehaviour
{
    public TextMeshProUGUI interactTip;
    public Camera playerCamera;

    public bool isInteractiveNow;

    [SerializeField] float maxInteractDistance;



    private void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, maxInteractDistance);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Interactive"))
            {
                interactTip.text = "'F' for interact";
                isInteractiveNow = true;
            }

            else
            {
                interactTip.text = " ";
                isInteractiveNow = false;
            }
        }
        else 
        {
            interactTip.text = " ";
            isInteractiveNow = false;
        }


        if (isInteractiveNow == true && Input.GetKeyDown(KeyCode.F))
        {
            InteractiveObject InteractObject = hit.collider.gameObject.GetComponent<InteractiveObject>();
            InteractObject.Interact(); 
        }
    }
}
