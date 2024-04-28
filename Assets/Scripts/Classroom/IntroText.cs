using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogueNPC("Sit at your seat and get ready for class.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
        gameObject.SetActive(false);
    }
}