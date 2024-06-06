using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship : MonoBehaviour
{
    public static int relationship = 0;
    public void PlusRelation()
    {
        relationship += 1;
    }
    public void MinusRelation()
    {
        relationship -= 1;
    }
}
