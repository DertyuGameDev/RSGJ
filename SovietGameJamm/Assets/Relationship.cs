using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship : MonoBehaviour
{
    public static int relationship;
    void Start()
    {
        relationship = 0;
        DontDestroyOnLoad(gameObject);
    }
    public void PlusRelation()
    {
        relationship += 1;
    }
    public void MinusRelation()
    {
        relationship -= 1;
    }
}
