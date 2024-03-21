using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public Transform raycastOrigin; 
    public float raycastDistance = 3f;
    public LayerMask layerMask;
    public TMP_Text myText;


    void Update()
    {
        shootRaycast();
    }

    void shootRaycast(){
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.up, raycastDistance, layerMask);
        if (hit.collider != null)
        {   
            myText.text = "Look at the ticket lady in the front! Don't bump into her if you don't have a ticket.";
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
