using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            dialogueSystem.StartDialogueNPC("Now you can run with LeftShift.");
        }
    }
}
