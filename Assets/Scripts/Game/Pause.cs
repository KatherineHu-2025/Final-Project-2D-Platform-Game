using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public DialogueSystem dialogueSystem; 
    public GameObject Menu;              
    public GameObject ConfirmationPage;  

    public static bool gameIsPaused = false; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        Menu.SetActive(true);
        dialogueSystem.EndDialogue(); 
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        Menu.SetActive(false);
        ConfirmationPage.SetActive(false);
    }

    public void QuitGame()
    {
        Menu.SetActive(false);
        ConfirmationPage.SetActive(true);
    }

    public void ConfirmQuit()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
