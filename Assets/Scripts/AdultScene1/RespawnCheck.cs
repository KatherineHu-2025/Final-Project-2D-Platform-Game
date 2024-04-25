using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform currentCheckpoint; //Stores the last checkpoint here

    public static int respawnCount = 0;
    public DialogueSystem dialogueSystem;

    public static bool freelanceCheck = false;
    public static int caughtCount = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint that was just activated as the current one
            collision.GetComponent<BoxCollider2D>().enabled = false; //deactivate checkpoint collider
            Debug.Log("checkpoint reached. Current checkpiont is " + currentCheckpoint);

            if(currentScene.name == "Freelance"){
                freelanceCheck = true;
            }
        }

        if (collision.transform.tag == "TicketLady" && !Character.withTicket)
        {
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
            respawnCount++;
            caughtCount++;
        }

        if (collision.transform.tag == "Restart")
        {   
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
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
            SceneManager.LoadScene("Achievements");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spikes")
        {
            transform.position = currentCheckpoint.position; //reset player's position to checkpoint's position
            respawnCount++;
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
