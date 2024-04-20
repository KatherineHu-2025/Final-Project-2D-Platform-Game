using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnterCueScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int time = 0;
    private int count = ReloadCounter.reloadCount;

    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(count == 0){

            }
            if(time == 0 && count == 0){
                dialogueSystem.StartDialogueNPC("It's 9 o' clock now. Start making money! You need to make 30$.");
                time++;
            }
            else if(time == 0 && count == 1){
                dialogueSystem.StartDialogueNPC("...That's a clumsy mistake! Don't make it again.");
            }   
            else if(time == 0 && count > 1){
                dialogueSystem.StartDialogueNPC("Hey BAHAVE YOURSELF. I said the boss IS WATCHING.");
            }
            else{
                dialogueSystem.StartDialogueNPC("Don't wander around! Go work! The boss is watching.");
            }
        }
    }
}
