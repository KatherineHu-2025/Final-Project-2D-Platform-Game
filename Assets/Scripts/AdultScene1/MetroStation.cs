using UnityEngine;

public class MetroStation : MonoBehaviour
{    
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            dialogueSystem.StartDialogueNPC("Please go to the ticket machine to buy train ticket.");
        }
    }
}
