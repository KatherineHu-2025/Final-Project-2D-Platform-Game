using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TicketMachine : MonoBehaviour
{
    public Transform raycastOrigin; 
    public float raycastDistance = 3f;
    public LayerMask layerMask;
    public TMP_Text myText;
    public GameObject menu;

    private GameObject ticket;

    public AudioSource ticketAudioSource;


    void Update()
    {
        shootRaycast();
    }

    void shootRaycast(){
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.up, raycastDistance, layerMask);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {   
            myText.text = "Press 'B' to buy ticket. 'Y' for Yes, 'N' for No.";
            PopMenu(hit);
        }
    }

    void PopMenu(RaycastHit2D hit){
        if(Input.GetKeyDown(KeyCode.B)){
            ticket = Instantiate(menu, transform.position + Vector3.up*3, transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.Y) && Character.money >= 5){    
                hit.collider.gameObject.GetComponent<Character>().BuyTicket();
                Character.money -= 5;
                Destroy(ticket);
                ticketAudioSource.Play();
            }
        else if(Input.GetKeyDown(KeyCode.N)){
            Destroy(ticket);
        }

    }

    void OnDrawGizmos()
    {
        if (raycastOrigin != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.up * raycastDistance);
        }
    }
}
