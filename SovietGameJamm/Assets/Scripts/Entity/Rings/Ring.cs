using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ring : MonoBehaviour
{

    public GameObject marker;
    public bool isFinal;

    private void Start()
    {
        Ringmanager.targets.Add(gameObject);
    }
    private void Update()
    {
        marker.transform.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !(isFinal && (Ringmanager.score < Ringmanager.targets.Count - 1))) {

            Ringmanager.AddScore();
            print("ColliderHit");
            
            if (isFinal) {
                Ringmanager.inst.finishedCourse.Invoke();
            }
            gameObject.SetActive(false);
        }
    }
}
