using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YesButton : MonoBehaviour
{
    public TMP_Text myText;
    public GameObject NoButton;

    public GameObject thisButton;
    public TMP_Text buttonText;

    private Image buttonImage;

    void Start()
    {
        buttonImage = thisButton.GetComponent<Image>();
    }

    public void Pressed()
    {
        Destroy(NoButton);
        removeButton();
        StartCoroutine(Press());
    }
    IEnumerator Press()
    {
        myText.text = "As you wished.";
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main Menu");
    }

    private void removeButton()
    {
        Color buttonColor = buttonImage.color;
        buttonColor.a = 0f; // Set alpha to 0
        buttonImage.color = buttonColor;
        Color textColor = buttonText.color;
        textColor.a = 0f; // Set alpha to 0
        buttonText.color = textColor;
    }
}
