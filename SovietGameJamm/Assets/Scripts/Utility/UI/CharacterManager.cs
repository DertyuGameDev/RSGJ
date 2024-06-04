using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    public Image character;
    public RectTransform charRt;
    public bool isSpeaking;
    public bool facingLeft;
    public bool isLeft;
    // Start is called before the first frame update
    public void changeCharacter(Sprite s) {
        character.gameObject.SetActive(s != null);
        if (s)
        {
            character.sprite = s;
        }
    }
    
    public void flipDir() {
        facingLeft = !facingLeft;
        charRt.transform.localScale = new Vector3(-charRt.transform.localScale.x, 1, 1);
    }

    public void changeDir(bool facingLeftp)
    {
        facingLeft = facingLeftp;
        charRt.transform.localScale = new Vector3((facingLeftp)?-1:1, 1, 1);
    }

    public void speakingMode(bool leftspeaking) {
        isSpeaking = (leftspeaking == isLeft);
    
    }
}
