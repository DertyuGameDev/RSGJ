using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class QTEManager : MonoBehaviour
{
    public Slider sl;
    public Image right;
    public Image left;
    public AnimationCurve speedinc;
    public AnimationCurve AcceptableRange;
    public float globalTime;
    private float t;
    public bool inc;
    public UnityEvent success;
    public UnityEvent fail;
    public float last;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fil = 0.5f - (AcceptableRange.Evaluate(globalTime) / 2);
        left.fillAmount = fil;
        right.fillAmount = fil;
        globalTime += Time.deltaTime;
        t += Time.deltaTime;
        if (inc)
        {
            sl.value = Mathf.Lerp(sl.maxValue, sl.minValue, t / speedinc.Evaluate(globalTime));
        }
        else
        {
            sl.value = Mathf.Lerp(sl.minValue, sl.maxValue, t / speedinc.Evaluate(globalTime));
        }
        if (Mathf.Approximately(sl.value, sl.maxValue) || Mathf.Approximately(sl.value, sl.minValue))
        {
            inc = !inc;
            t = 0;
        }
    }

    public void hit()
    {
        if (Time.time - last > 0.1f)
        {
            last = Time.time;
            if (Mathf.Abs(sl.value) <= AcceptableRange.Evaluate(globalTime) / 2)
            {

                print("hit" + globalTime);
                success.Invoke();
                
            }
            else
            {
                fail.Invoke();
            }
        }
        
    }
}


