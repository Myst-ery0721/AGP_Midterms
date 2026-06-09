using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI Name;

    public DialogueLines dialogueLines;

    public int currentDialogueIndex;
    public int currentPromptIndex;
    public int totalNumberofLines => dialogueLines.dialoguePrompt[currentPromptIndex].lines.Length;
    
    void Start()
    {
        RefreshUI();
    }

    void Update()
    {
        
        //display first index of the array
        //get the scriptable object array
        if (Input.GetMouseButtonDown(0))
        {
            if (currentDialogueIndex < totalNumberofLines - 1)
            {
                currentDialogueIndex++;
            }
            else
            {
                currentPromptIndex++;
                if (currentPromptIndex >= dialogueLines.dialoguePrompt.Length)
                {
                    return;
                }
                currentDialogueIndex = 0;

            }
            RefreshUI();
        }
        
    }
    public void RefreshUI()
    {
        var entry = dialogueLines.dialoguePrompt[currentPromptIndex];
        dialogueText.text = entry.lines[currentDialogueIndex];
        Name.text = entry.speakerName;
        dialogueText.text = entry.lines[currentDialogueIndex];
    }
}
