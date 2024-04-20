using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            dialogueSystem.StartDialogueNPC("Look at the ticket lady in the front! Don't bump into her if you don't have a ticket.");
        }
    }
}
