using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SchoolText : MonoBehaviour
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

            if (hit.collider.CompareTag("Playground"))
            {
                Debug.Log("playground");
                myText.text = "Where are you going? The classroom is to the right!";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("Door"))
            {
                myText.text = "Skipping class? This could affect your future options...";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("Class"))
            {
                myText.text = "It may be boring, but it will help you in the future!";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
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
