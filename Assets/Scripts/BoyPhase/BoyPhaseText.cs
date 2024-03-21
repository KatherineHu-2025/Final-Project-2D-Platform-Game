using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoyPhaseText : MonoBehaviour
{
    public Transform raycastOrigin;
    public float raycastDistance = 3f;
    public LayerMask layerMask;
    public TMP_Text myText;


    void Update()
    {
        shootRaycast();
    }

    void shootRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.up, raycastDistance, layerMask);
        if (hit.collider != null)
        {
            //Debug.Log("collider hit"  + hit.collider);
            if (hit.collider.CompareTag("Tutorial"))
            {
                //Debug.Log("tutorial");
                myText.text = "Good Morning! It's time to go to school! Use the A and D keys to move, and Space to Jump.";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("Gaps"))
            {
                myText.text = "These gaps are easy! You got this.";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("CheckpointText"))
            {
                myText.text = "Nice! You made it to a checkpoint.";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("Bus"))
            {
                myText.text = "You made it to the bus stop! The bus (platform) will be arriving shortly.";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("School"))
            {
                myText.text = "Congrats! You made it to school! Go through the door to advance.";
                hit.collider.GetComponent <BoxCollider2D>().enabled = false;
            }
            
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
