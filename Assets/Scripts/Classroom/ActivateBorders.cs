using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBorders : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;

    //private BoxCollider2D objectCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leftBorder.SetActive(true);
            rightBorder.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
