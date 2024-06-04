using UnityEngine;

[System.Serializable]
public struct Options
{
    public string optName;
    public Dialogue next;
}

[System.Serializable]
public struct Character
{
    public string charName;
    public Sprite cha;
    public bool facingLeft;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueSystem/Dialogue", order = 5)]
public class Dialogue : ScriptableObject
{
    public Character Left;
    public Character Right;
    public bool isLeftSpeaking;
    
    public string[] lines;
    public string[] defResponses;
    public Options[] opt;
    
}
