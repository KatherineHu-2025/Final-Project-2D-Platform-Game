using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivate : MonoBehaviour
{
    public GameObject border_l;
    public GameObject border_r;

    //public GameObject doorTrigger;

    private void Update()
    {
        if (BoyMovement.pages >= 20)
        {
            border_l.SetActive(false);
            border_r.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
