using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherMonologue : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public Sprite teacherPortrait;

    //public GameObject border;
    //private int count = 0;

    private void Update()
    {
        if (BoyMovement.pages >= 20)
        {
            dialogueSystem.EndDialogue();
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueSystem.StartDialogue("Good morning class! For today, please read 20 pages in the workbook.", teacherPortrait);
        //StartCoroutine(WaitToEnd());
        //dialogueSystem.EndDialogue();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueSystem.EndDialogue();
    }

    //private void Monologue()
    //{
    //    if (Input.GetKey(KeyCode.KeypadEnter))
    //    {
    //        if (count == 0)
    //        {
    //            dialogueSystem.EndDialogue();
    //            dialogueSystem.StartDialogue("Last time, we covered adding and subtracting basic numbers.", teacherPortrait);
    //            count++;
    //        }

    //        if (count == 1)
    //        {
    //            Debug.Log("count is 1");
    //        }
    //    }
    //}

    //IEnumerator WaitToEnd()
    //{
    //    yield return new WaitForSecondsRealtime(1f);
    //    dialogueSystem.EndDialogue();
    //}


    //private void TeacherText()
    //{

    //    dialogueSystem.StartDialogue("Last time, we covered adding and subtracting basic numbers.", teacherPortrait);
    //    StartCoroutine(NextLine());

    //}

    //IEnumerator NextLine()
    //{
    //    //dialogueSystem.EndDialogue();
    //    Debug.Log("when is this called?");
    //    yield return new WaitForSecondsRealtime(3f);
    //    Debug.Log("is this called 3 seconds after?");


    //dialogueSystem.StartDialogue("Last time, we covered adding and subtracting basic numbers.", teacherPortrait);
    //yield return new WaitForSecondsRealtime(3f);
    //dialogueSystem.EndDialogue();

}

