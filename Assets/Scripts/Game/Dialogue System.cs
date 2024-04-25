using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text dialogueText;
    public GameObject dialoguePanel; 
    public Image npcPortrait; 
    public Sprite godSprite;

    [SerializeField]
    private float typingSpeed = 0.005f;

    void Start()
    {
        dialoguePanel.SetActive(false); 
    }

    public void StartDialogue(string dialogue, Sprite portrait)
    {
        dialoguePanel.SetActive(true); // Show the dialogue UI
        dialogueText.text = ""; // Set the dialogue text
        npcPortrait.sprite = portrait; // Set the NPC's portrait
        StartCoroutine(TypeDialogue(dialogue));
    }

    public void StartDialogueNPC(string dialogue)
    {
        dialoguePanel.SetActive(true); // Show the dialogue UI
        dialogueText.text = ""; // Set the dialogue text
        npcPortrait.sprite = godSprite; // Set the NPC's portrait
        StartCoroutine(TypeDialogue(dialogue));
    }

    IEnumerator TypeDialogue(string dialogue)
    {
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Wait before showing next character
        }
    }

    public void EndDialogue()
    {   
        StopAllCoroutines();
        dialoguePanel.SetActive(false); 
    }
}
