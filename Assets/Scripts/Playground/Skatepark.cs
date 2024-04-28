using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skatepark : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogueNPC("A school with a skatepark? Nice.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
    }
}
