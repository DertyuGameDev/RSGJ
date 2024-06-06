using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class Ringmanager : MonoBehaviour
{
    public static int score;
    public static List<GameObject> targets;
    public TMP_Text scd;
    public static Ringmanager inst;
    public UnityEvent finishedCourse;
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        targets = new List<GameObject>();
        inst = this;
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        upDisp();
    }
    void upDisp()
    {
        scd.text = $"{score} / {targets.Count}";
    }
    public static void AddScore() {
        score++;
    }
}
