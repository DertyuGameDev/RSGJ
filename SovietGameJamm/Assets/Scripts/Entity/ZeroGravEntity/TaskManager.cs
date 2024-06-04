using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerUI;

    private void Update()
    {
        timerUI.text = $"{ Time.time }";
    }
}
