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
        if (BoyMovement.pages >= 30)
        {
            border_l.SetActive(false); //deactive the desk borders
            border_r.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true; //activate the door collider
        }
    }
}
