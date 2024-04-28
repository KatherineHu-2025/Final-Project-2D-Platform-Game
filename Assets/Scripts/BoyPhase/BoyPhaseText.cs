using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyPhaseText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tutorial"))
        {
            dialogueSystem.StartDialogueNPC("Good Morning! It's time to go to school! Use the A and D keys to move, and Space to Jump.");
        }

        if (collision.CompareTag("Gaps"))
        {
            dialogueSystem.StartDialogueNPC("These gaps are easy! You got this.");
        }

        if (collision.CompareTag("CheckpointText"))
        {
            dialogueSystem.StartDialogueNPC("Nice! You made it to a checkpoint.");
        }

        if (collision.CompareTag("Bus"))
        {
            dialogueSystem.StartDialogueNPC("You made it to the bus stop! The bus (platform) will be arriving shortly.");
        }

        if (collision.CompareTag("School"))
        {
            dialogueSystem.StartDialogueNPC("Congrats! You made it to school! Go through the door to advance.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (!collision.CompareTag("Restart"))
        {
            dialogueSystem.EndDialogue();
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }
}
