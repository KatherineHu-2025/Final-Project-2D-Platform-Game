using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SchoolText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Day"))
        {
            dialogueSystem.StartDialogueNPC("Another day at school...");
        }

        if (collision.CompareTag("Playground"))
        {
            dialogueSystem.StartDialogueNPC("Where are you going? The classroom is to the right!");
        }

        if (collision.CompareTag("Door"))
        {
            dialogueSystem.StartDialogueNPC("Skipping class? This could affect your future options...");
        }

        if (collision.CompareTag("Class"))
        {
            dialogueSystem.StartDialogueNPC("Study hard for a good future!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
    }

}


