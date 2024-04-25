using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFreelance : MonoBehaviour
{
   public DialogueSystem dialogueSystem;
    private bool isPlayerInRange = false; // To check if the player is within the interaction range

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("Freelance");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit by player");
            dialogueSystem.StartDialogueNPC("Press 'Y' if you are ready to face the unknown. It's difficult.");
            isPlayerInRange = true; // Player is now in range for interaction
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.EndDialogue();
            isPlayerInRange = false; // Player has left the interaction range
        }
    }
    
}
