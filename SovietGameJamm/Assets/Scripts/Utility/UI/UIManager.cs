using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager inst;
    public GameObject speakingPanel;
    public TMP_Text dlog;
    public TMP_Text nam;
    // Start is called before the first frame update
    void Awake()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void toggleSpeakingPanel(bool s) {
        inst.speakingPanel.SetActive(s);
    }
    public static void updateTextDisplay(string s)
    {
        inst.dlog.text = s;
    }

    public static void updateNameDisplay(string s,bool isLeftTalking)
    {
        inst.nam.text = s;
        if (isLeftTalking)
        {
            inst.nam.horizontalAlignment = HorizontalAlignmentOptions.Left;
        }
        else {
            inst.nam.horizontalAlignment = HorizontalAlignmentOptions.Right;
        }
    }
}
