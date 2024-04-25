using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource buttonClick;

    public void ClickButton(){
        buttonClick.Play();
    }
}
