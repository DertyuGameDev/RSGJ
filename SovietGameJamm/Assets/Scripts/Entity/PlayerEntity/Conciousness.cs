using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Conciousness : MonoBehaviour
{
    public float conciousness = 100f;
    public float maxconciousness = 100f;
    public RotateCentrifuge rc;
    public QTEManager qm;
    public Image SanityBar;
    public bool dead = false;
    public UnityEvent loss;
    public UnityEvent win;
    // Start is called before the first frame update
    void Start()
    {
        qm.success.AddListener(IncreaseConciousness);
        qm.fail.AddListener(DecreaseConciousness);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!dead)
        {
            if (rc.t >= rc.simulationTime*1.3f)
            {
                win.Invoke();
                dead = true;
            }
            if (conciousness >= 0f)
            {
                conciousness -= ((rc.currG * rc.currG) / 10f) * Time.deltaTime;
            }
            else {
                
                conciousness = 0;
                loss.Invoke();
                dead = true;
            }
        }
        SanityBar.fillAmount = conciousness / maxconciousness;
    }

    public void IncreaseConciousness() {
        float val = Random.Range(((rc.currG * rc.currG) / 12f), ((rc.currG * rc.currG) / 8f)) *1.5f;
        if (conciousness + (val) > maxconciousness)
        {
            conciousness = maxconciousness;
        }
        else {
            conciousness += (val);
        }
    }
    public void DecreaseConciousness()
    {
        float val = Random.Range(((rc.currG * rc.currG) / 16f), ((rc.currG * rc.currG) / 13f));
        if (conciousness - val < 0)
        {
            conciousness = 0;
        }
        else
        {
            conciousness -= val;
        }
    }
}
