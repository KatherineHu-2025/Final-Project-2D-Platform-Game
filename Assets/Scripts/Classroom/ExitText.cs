using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogueNPC("Excellent work! Exit through the door to go home.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
    }

}
