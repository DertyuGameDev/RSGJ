using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRun : MonoBehaviour
{
    public Dialogue Dialogue, Dialogue1;
    public void OnTriggerEnter()
    {
        if (Relationship.relationship > 0)
        {
            DialogHelper.startd(Dialogue);
        }
        else
        {
            DialogHelper.startd(Dialogue1);
        }
        GetComponent<BoxCollider>().enabled = false;
    }
}
