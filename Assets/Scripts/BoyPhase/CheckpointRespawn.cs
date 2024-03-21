using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointRespawn : MonoBehaviour
{
    private Transform currentCheckpoint; //Stores the last checkpoint here
    private int respawnCount = 0;
    public TMP_Text myText;


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
            Debug.Log("respawned");
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
        }
    }

    private void RespawnText()
    {
        
        if (respawnCount >= 10)
        {
            myText.text = "...";
        }

        else
        {
            myText.text = "That's rough. Keep going!";
        }
    }
}
