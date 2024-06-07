using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RotateCentrifuge : MonoBehaviour
{
    public float targetG;
    public float currG;
    public float targetRPM;
    public float currRPM;
    public float simulationTime;
    public float t;
    public AnimationCurve speed;
    const float mag = 0.001118f * 2.71125f;
    public TMP_Text GDisp;
    // Start is called before the first frame update
    void Start()
    {
        currG = 0;
        currRPM = 0;
        targetRPM = Mathf.Sqrt((targetG / mag));

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        currRPM = Mathf.Lerp(0, targetRPM, speed.Evaluate(t / simulationTime));
        currG = currRPM * currRPM * mag;
        GDisp.text = $"{currG:0.#}G";
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + (currRPM * 6 * Time.deltaTime), this.transform.eulerAngles.z);
    }
}
