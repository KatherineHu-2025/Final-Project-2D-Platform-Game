using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    //public GameObject UIText;
    public GameObject Menu;

    public static bool gameIsPaused;

    private void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Menu.gameObject.SetActive(true);
            //UIText.gameObject.SetActive(false);
        }

        else
        {
            Time.timeScale = 1;
            //Menu.gameObject.SetAc UIText.gameObject.SetActive(true);
        }
    }
}
