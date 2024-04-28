using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Memoir : MonoBehaviour
{
    public TMP_Text myText;

    private String[] content = new String[6];
    private int number = 0;
    private int money = Character.money;
    private int deathAmount = RespawnCheck.respawnCount;
    private bool withTicket = Character.withTicket;
    private int caughtCount = RespawnCheck.caughtCount;
    private bool reachedFreelance = RespawnCheck.freelanceCheck;
    private bool withInsurance = Character.withInsurance;

    private bool classroom = false;
    private bool playground = false;


    void Start()
    {

        CheckStudiedOrPlayed();
        AddContent();
    }

    private void AddContent(){
        //deathAmount
        if(deathAmount < 10){
            content[0] = "Responsible to your life. \n" + deathAmount + " minor setbacks didn't stop you from going.";
        }
        else if(deathAmount >= 10){
            content[0] = "You fell "+ deathAmount + " times.\n But you're known for your cockroach spirit - never dies!";
        }

        //classroom and playground
        if (classroom)
        {
            content[1] = "A diligent student, you studied to have an easier future.";
        }
        else if (playground)
        {
            content[1] = "A true rebel, you skipped class to go to the playground and made some lasting memories.";
        }

        //withTicket and caughtCount
        if(withTicket){
            content[2] = "You've always been a lawful citizens.\nYou buy your metro tickets. Good for you!";
        }
        else{
            if(caughtCount > 0){
                content[2] = "You've always been an outlaw -- not a very skilled one.\n You got caught by the ticketlady" + caughtCount + " times.";
            }
            else{
                content[2] = "You've always been an prefessional outlaw.\n You have your own way to skip the ticket inspection and never get caught!";
            }
        }

        if(!reachedFreelance){
            content[3] = "You worked in a regular office.";
            if(Boss.isCaught){
                content[4] = "However, you got caught when you tried to sneak out! Bruh.";
            }
            else{
                content[4] = "According to your boss observation, you've been a dedicated worker.";
            }
        }
        else{
            content[3] = "You worked as a freelancer.\n Lots of pain and sweat to earn money.";
            if(withInsurance){
                content[4] = "You are a cautious person.\n You bought the insurance!";
            }
            else{
                content[4] = "You are a risk bearer.\n What is insurance? Never heard of it.";
            }
        }

        //Money
        if(money == 30){
            content[5] = "You're a responsible money maker.\n You earned " + money + " dollars";
        }
        else if(money < 30){
            content[5] = "You have a rough time making money.\n You've only made " + money + " dollars. Should've switch your path huh?";
        }
        else{
            content[5] = "You're an overachiever with an eager to make money.\n Congratulations on making " + money + " dollars!";
        }
    }

    public void Press(){
        if(number < 6){
            myText.text = content[number];
            number ++;
        }
        else{
            SceneManager.LoadScene("Final");
        }
    }

    private void CheckStudiedOrPlayed()
    {
        if (BoyMovement.CheckPages() > 0)
        {
            classroom = true;
        }
        else
        {
            playground = true;
        }

    }
}
