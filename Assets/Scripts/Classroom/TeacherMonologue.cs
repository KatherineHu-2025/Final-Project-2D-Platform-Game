using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TeacherMonologue : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public Sprite teacherPortrait;

    public Slider pagesSlider;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            dialogueSystem.StartDialogue("Good morning class! For today, please read 30 pages in the workbook.\n" +
                "You can leave after you finish your 30 pages.", teacherPortrait);
        //StartCoroutine(WaitToEnd());
        //dialogueSystem.EndDialogue();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

}


