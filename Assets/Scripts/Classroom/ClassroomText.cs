using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomText : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public Sprite teacherPortrait;

    private void Start()
    {
        dialogueSystem.StartDialogueNPC("Class time! Read 20 pages and listen \n" +
            "to your teacher's lecture. Then you can leave the classroom.");
        //NextLine();
        //TeacherText();
    }

    //private void Update()
    //{
    //    if (dialogueSystem != null)
    //    {
    //        TeacherText();
    //    }
    //}

    
}
