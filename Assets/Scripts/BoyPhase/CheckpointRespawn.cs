using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointRespawn : MonoBehaviour
{
    private Transform currentCheckpoint; //Stores the last checkpoint here
    private int respawnCount = 0;
    public DialogueSystem dialogueSystem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint that was just activated as the current one
            collision.GetComponent<BoxCollider2D>().enabled = false; //deactivate checkpoint collider
            Debug.Log("checkpoint reached. Current checkpiont is " + currentCheckpoint);
        }

        if (collision.transform.tag == "Restart")
        {
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
            Debug.Log("respawncount is:" + respawnCount);
            respawnCount++;
            RespawnText();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spikes")
        {
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
            Debug.Log("hit spikes");
            respawnCount++;
            RespawnText();
        }
    }

    private void RespawnText()
    {
        if (respawnCount <= 5)
        {
            dialogueSystem.StartDialogueNPC("That's rough. Keep going!");
        }

        if (respawnCount > 5 && respawnCount <= 10)
        {
            dialogueSystem.StartDialogueNPC("Don't give up!");
        }

        if (respawnCount > 10 && respawnCount <= 15)
        {
            dialogueSystem.StartDialogueNPC("Come on, it's not THAT hard...");
        }

        if (respawnCount > 15)
        {
            dialogueSystem.StartDialogueNPC("...");
        }
    }


}
