using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResponseButton : MonoBehaviour
{

    public string nam;
    public Dialogue d;
    public TMP_Text t;
    // Start is called before the first frame update

    public void init(string s, Dialogue dt)
    {
        nam = s;
        t.text = nam;
        d = dt;
    }
    public void onPress() {
        if (d)
        {
            DialogHelper.next(d);
        }
        else {
            DialogHelper.next();
        }
    }

}
