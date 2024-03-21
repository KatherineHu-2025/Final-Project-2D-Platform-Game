using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void EndGame(){
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
