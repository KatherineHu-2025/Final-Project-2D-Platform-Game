using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToOffice : MonoBehaviour
{
    public Transform raycastOrigin; 
    public float raycastDistance = 3f;
    public LayerMask layerMask;


    void Update()
    {
        shootRaycast();
    }

    void shootRaycast(){
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.up, raycastDistance, layerMask);
        if (hit.collider != null)
        {   
            SceneManager.LoadScene("Office");
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
