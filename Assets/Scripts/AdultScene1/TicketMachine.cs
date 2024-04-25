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
    public Sprite npc;

    void Update(){
        if(playerInRange){
            PopMenu(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            player = collision;
            playerInRange = true;
            dialogueSystem.StartDialogue("Press 'B' to buy ticket. 'Y' for Yes, 'N' for No.",npc);
            if(Character.withTicket){
                dialogueSystem.StartDialogue("You've already bought the ticket!",npc);
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
                dialogueSystem.StartDialogue("It seems you don't have enough money...Good luck!",npc);
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
