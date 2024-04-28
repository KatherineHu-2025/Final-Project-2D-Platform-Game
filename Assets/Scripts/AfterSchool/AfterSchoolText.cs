using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterSchoolText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BikeStart"))
        {
            dialogueSystem.StartDialogueNPC("Time to go home! Hop on your bike (spinning platforms).");
        }

        if (collision.CompareTag("SpikeText"))
        {
            dialogueSystem.StartDialogueNPC("Going home can be dangerous. Watch out for the spikes!");
        }

        if (collision.CompareTag("Platform"))
        {
            dialogueSystem.StartDialogueNPC("Almost there!");
        }

        if (collision.CompareTag("End"))
        {
            dialogueSystem.StartDialogueNPC("Congratulations on finishing your boyhood! Prepare yourself for the next phase of your life.");
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
