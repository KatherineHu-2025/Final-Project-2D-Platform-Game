using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterSchoolText : MonoBehaviour
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
            Debug.Log("collider hit" + hit.collider);
            if (hit.collider.CompareTag("SpikeText"))
            {
                myText.text = "Going home can be dangerous. Watch out for the spikes!";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("Platform"))
            {
                myText.text = "Almost there!";
                hit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (hit.collider.CompareTag("End"))
            {
                myText.text = "Congratulations on finishing your boyhood! Prepare yourself for the next phase of your life.";
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
