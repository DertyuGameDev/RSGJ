using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Valve : MonoBehaviour
{

    public float timeToComplete;
    private float t;
    bool interacting = false;
    public Image progress;
    public GameObject part;
    public GameObject valve;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        timeToComplete = Random.Range(0.5f, 1.5f);
        Ringmanager.targets.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        interacting = (Vector3.Distance(this.transform.position, Camera.main.transform.position) <= radius) && Input.GetAxis("Fire1")>0;
        
        if (interacting && t <= timeToComplete) {
            t += Time.deltaTime;
            valve.transform.localEulerAngles = new Vector3(0,0,  Mathf.Lerp(0, 340, t / timeToComplete));
            progress.fillAmount = t / timeToComplete;
            if (t >= timeToComplete) {
                part.SetActive(false);
                progress.fillAmount = 0;
                
                Ringmanager.AddScore();
                if (Ringmanager.score == Ringmanager.targets.Count) {
                    Ringmanager.inst.finishedCourse.Invoke();
                }
            }
        }

        
    }

   
}
