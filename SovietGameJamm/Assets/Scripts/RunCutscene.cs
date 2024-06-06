using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCutscene : MonoBehaviour
{
    public string Cutscene, Cutscene2;
    bool can = true;
    bool can2 = true;
    public Animator animator;

    public void Line(string line1)
    {
        if (can)
        {
            CutsceneManager.Instance.StartCutscene(Cutscene);
            can = false;
        }
        else if (can == false && can2)
        {
            CutsceneManager.Instance.StartCutscene(Cutscene2);
            can2 = false;
        }
    }
    public void Anim(string line1)
    {
        if (line1 == "1")
        {
            animator.SetTrigger("Write");
        }
    }
}
