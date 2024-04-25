using System.Collections;
using UnityEngine;
using TMPro;

public class BossRegionCue : MonoBehaviour
{
    // Start is called before the first frame update
    private int time = 0;
    public Sprite boss;

    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(Character.CheckMoney() < 30){
                if(time == 0){
                    dialogueSystem.StartDialogueNPC("Go back to work! Don't sneak out when boss is WATCHING!");
                    time++;
                }
                else{
                    dialogueSystem.StartDialogueNPC("DO YOU REALLY WANT TO DO THIS?");
                }
            }
            else{
                dialogueSystem.StartDialogue("Your work for today is done. You can leave now!",boss);
            }
        }
    }
}
