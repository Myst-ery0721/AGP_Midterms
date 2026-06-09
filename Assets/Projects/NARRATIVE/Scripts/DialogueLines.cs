using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLines", menuName = "Scriptable Objects/DialogueLines")]
public class DialogueLines : ScriptableObject
{
    public DialogueEntry[] dialoguePrompt;

}
[System.Serializable]
public class DialogueEntry
{
    public string speakerName;
    [TextArea]
    public string[] lines;
}
