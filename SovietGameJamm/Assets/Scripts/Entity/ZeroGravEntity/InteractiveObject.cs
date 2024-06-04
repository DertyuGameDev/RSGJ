using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public enum interactTypes
    {
        valve,
        button,
    }

    public interactTypes InteractType;

    [SerializeField] float interactionTime = 0.1f;

    public void Interact()
    {
        if (InteractType == interactTypes.valve) 
        {
            Debug.Log("valve");
        }
    }

}
