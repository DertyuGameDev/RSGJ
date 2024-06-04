using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsePanelHelper : MonoBehaviour
{
    public static ResponsePanelHelper inst;
    public static List<GameObject> responseButtons;
    public GameObject respButt;
    public GameObject responsesPanel;
    // Start is called before the first frame update
    void Start()
    {
        inst = this;
        responseButtons = new List<GameObject>();
        responsesPanel = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void addResponse(string name, Dialogue d) {
        var g = Instantiate(inst.respButt,inst.responsesPanel.transform);
        g.GetComponent<ResponseButton>().init(name, d);
        responseButtons.Add(g);
    }
    public static void addResponse(string name)
    {
        var g = Instantiate(inst.respButt, inst.responsesPanel.transform);
        g.GetComponent<ResponseButton>().init(name,null);
        responseButtons.Add(g);
    }

    public static void clearResponses() {
        List<GameObject> t = new List<GameObject>(responseButtons);
        foreach (GameObject g in t) {
            responseButtons.Remove(g);
            Destroy(g);
        }
    }
}
