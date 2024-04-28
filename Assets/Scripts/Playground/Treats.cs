using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treats : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogueNPC("If you had treats, you could feed these dogs with 'F'!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
    }
}
