using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoButton : MonoBehaviour
{
    public TMP_Text myText;
    public GameObject YesButton;
    public GameObject thisButton;
    public TMP_Text buttonText;

    private Image buttonImage;

    void Start()
    {
        buttonImage = thisButton.GetComponent<Image>();
    }

    public void Pressed()
    {
        Destroy(YesButton);
        removeButton();
        StartCoroutine(Press());
    }

    IEnumerator Press()
    {
        myText.text = "There is no mistakes in life.";
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
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
