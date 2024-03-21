using UnityEngine;
using UnityEngine.SceneManagement;

public class TicketLady : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player") && !Character.withTicket){
            SceneManager.LoadScene("AdultScene1");
        }
    }
}
