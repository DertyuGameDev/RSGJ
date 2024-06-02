using UnityEngine;

[System.Serializable]
public struct Options
{
    public string optName;
    public Dialogue next;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueSystem/Dialogue", order = 5)]
public class Dialogue : ScriptableObject
{
    public string[] lines;
    public string[] defResponses;
    public Options[] opt;
    
}
