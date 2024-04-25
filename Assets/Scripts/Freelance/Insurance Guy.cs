using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsuranceGuy : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueSystem dialogueSystem;
    public Sprite npc;
    private int time = 0;
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Y))
        {   
            if(Character.money >= 10){
                ProcessInsurancePurchase();
                Character.money -= 10;
            }
            else{
                dialogueSystem.StartDialogue("Maybe wait till you have money man.", npc);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            isPlayerInRange = true;
            if (time == 0) // Assuming RespawnTime starts from 0 and increments before the player can trigger this
            {
                dialogueSystem.StartDialogue("Freelancing is a difficult and dangerous job! You should buy yourself health insurance! Or you'll have to pay the bill yourself.", npc);
                time++;
            }
            else
            {
                dialogueSystem.StartDialogue("Press 'Y' to buy the insurance. It's only $10 and it's permanent!", npc);
            }
        }
    }

    private void ProcessInsurancePurchase()
    {
        dialogueSystem.StartDialogue("Good Choice!", npc);
        Character.withInsurance = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.EndDialogue();
            isPlayerInRange = false;
        }
    }
}
