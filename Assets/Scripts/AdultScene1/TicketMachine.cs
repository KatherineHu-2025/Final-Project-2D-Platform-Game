using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TicketMachine : MonoBehaviour
{
    public GameObject menu;

    private GameObject ticket;
    private bool playerInRange;
    private Collider2D player;

    public AudioSource ticketAudioSource;

    
    public DialogueSystem dialogueSystem;

    void Update(){
        if(playerInRange){
            PopMenu(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            player = collision;
            playerInRange = true;
            dialogueSystem.StartDialogueNPC("Press 'B' to buy ticket. 'Y' for Yes, 'N' for No.");
            if(Character.withTicket){
                dialogueSystem.StartDialogueNPC("You've already bought the ticket!");
            }
        }
    }

    void PopMenu(Collider2D collision){
        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("Pressed");
            ticket = Instantiate(menu, transform.position + Vector3.up*3, transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            if(Character.money >= 5){
                collision.gameObject.GetComponent<Character>().BuyTicket();
                Character.money -= 5;
                Destroy(ticket);
                ticketAudioSource.Play();
            }   
            else{
                dialogueSystem.StartDialogueNPC("It seems you don't have enough money...Good luck!");
                Destroy(ticket);
            }
        }
        else if(Input.GetKeyDown(KeyCode.N)){
            Destroy(ticket);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        playerInRange = false;
        dialogueSystem.EndDialogue();
    }
}
