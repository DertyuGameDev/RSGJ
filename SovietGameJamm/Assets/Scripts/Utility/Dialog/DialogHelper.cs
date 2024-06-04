using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHelper : MonoBehaviour
{
    public Dialogue di;
    public int ind = 0;
    public static DialogHelper inst;
    // Start is called before the first frame update
    void Start()
    {
        inst = this;
        startd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void startd() {
        UIManager.toggleSpeakingPanel(true);
        ResponsePanelHelper.clearResponses();
        if (inst.di) {
            inst.ind = 0;
            UIManager.updateTextDisplay(inst.di.lines[0]);
            if (inst.di.lines.Length > 1)
            {
                ResponsePanelHelper.addResponse(inst.di.defResponses[0]);
            }
            else {
                foreach (Options op in inst.di.opt) {
                    ResponsePanelHelper.addResponse(op.optName,op.next);
                }
            }
        }
    }

    public static void startd(Dialogue du)
    {
        inst.di = du;
        startd();
    }

    public static void next() {
        inst.ind++;
        ResponsePanelHelper.clearResponses();
        if (inst.ind <= inst.di.lines.Length - 1)
        {
            UIManager.updateTextDisplay(inst.di.lines[inst.ind]);
            if (inst.ind <= inst.di.defResponses.Length - 1)
            {
                ResponsePanelHelper.addResponse(inst.di.defResponses[inst.ind]);
            }
            else
            {
                foreach (Options op in inst.di.opt)
                {
                    ResponsePanelHelper.addResponse(op.optName, op.next);
                }
            }
        }
        else {
            UIManager.toggleSpeakingPanel(false);
        }
    }
    public static void next(Dialogue d)
    {
        startd(d);
    }
}
