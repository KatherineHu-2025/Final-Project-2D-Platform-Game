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
        }
    }
}
