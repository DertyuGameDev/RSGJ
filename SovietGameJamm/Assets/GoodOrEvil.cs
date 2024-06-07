using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodOrEvil : MonoBehaviour
{
    public Dialogue d1, d2;

    public void StartDialogue()
    {
        if (Relationship.relationship > 0)
        {
            DialogHelper.startd(d1);
        }
        else
        {
            DialogHelper.startd(d2);
        }
    }
}
