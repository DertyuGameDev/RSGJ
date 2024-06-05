using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public string cutscene;
    private void OnTriggerEnter(Collider other)
    {
        CutsceneManager.Instance.StartCutscene(cutscene);
    }
}
