using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public TMP_Text myText;

    public void ChangeText(string newString){
        myText.text = newString;
    }
    
}
