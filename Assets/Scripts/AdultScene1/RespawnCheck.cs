using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnCheck : MonoBehaviour
{
    // Start is called before the first frame update
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

        if (collision.transform.tag == "TicketLady" && !Character.withTicket)
        {
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
            Debug.Log("respawned");
            respawnCount++;
        }

        if (collision.transform.tag == "Restart")
        {   
            Scene currentScene = SceneManager.GetActiveScene();
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
            Debug.Log("respawned");
            if(!Character.withInsurance && currentScene.name == "Freelance"){
                 if(Character.money >= 5){
                    Character.money -= 5;
                }
                else{
                    Character.money = 0;
                }
            }
            respawnCount++;
            RespawnText();
            Debug.Log("Current Money is" + Character.money);
        }

        if (collision.transform.tag == "Final"){
            SceneManager.LoadScene("Final");
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
