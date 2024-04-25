using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Sprite door_open;
    public Sprite door_closed;
    public Sprite npc;
    public DialogueSystem dialogueSystem;
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(Character.money >= 30){
                dialogueSystem.StartDialogue("I think you made enough money,let's go home.",npc);
            }
            else{
                dialogueSystem.StartDialogue("Are you sure? You only have "+Character.money+ "$. Guess you're not an ambitious person, aren't you?",npc);
            }
            spriteRenderer.sprite = door_open;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        dialogueSystem.EndDialogue();
        spriteRenderer.sprite = door_closed;
    } 
    
}
