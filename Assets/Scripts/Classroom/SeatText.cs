using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public Sprite teacherPortrait;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogue("Good morning class! For today, please read 20 pages in the workbook.", teacherPortrait);
            //dialogueSystem.StartDialogueNPC("" +
            //    "" +
            //    "Read 20 pages, then walk up and listen to your teacher's lecture. \n" +
            //    " Then you can leave the classroom.");
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    dialogueSystem.EndDialogue();
    //}
}
