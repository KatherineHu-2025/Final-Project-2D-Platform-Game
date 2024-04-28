using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStart : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public static bool boyPlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boyPlayed = true;
            dialogueSystem.StartDialogueNPC("Well, since you're here, might as well enjoy yourself.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
    }
}
