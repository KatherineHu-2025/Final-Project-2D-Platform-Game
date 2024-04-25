using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Memoir : MonoBehaviour
{
    public TMP_Text myText;

    private String[] content = new String[5];
    private int number = 0;
    private int money = Character.money;
    private int deathAmount = RespawnCheck.respawnCount;
    private bool withTicket = Character.withTicket;
    private int caughtCount = RespawnCheck.caughtCount;
    private bool reachedFreelance = RespawnCheck.freelanceCheck;
    private bool withInsurance = Character.withInsurance;


    void Start(){
        AddContent();
    }

    private void AddContent(){
        //deathAmount
        if(deathAmount < 10){
            content[0] = "You are responsible to your life." + deathAmount + " minor setbacks didn't stop you from going.";
        }
        else if(deathAmount >= 10){
            content[0] = "Although you falled "+ deathAmount + " times, but you're known for your cockroach spirit - never dies!";
        }


        //withTicket and caughtCount
        if(withTicket){
            content[1] = "You've always been a lawful citizens. You buy your metro tickets. Good for you!";
        }
        else{
            if(caughtCount > 0){
                content[1] = "You've always been an outlaw -- not a very skilled one. You got caught by the ticketlady" + caughtCount + " times.";
            }
            else{
                content[1] = "You've always been an prefessional outlaw. You have your own way to skip the ticket inspection and never get caught!";
            }
        }

        if(!reachedFreelance){
            content[2] = "You worked in a regular office. ";
            if(Boss.isCaught){
                content[3] += "However, you got caught when you tried to sneak out! Bruh.";
            }
            else{
                content[3] += "According to your boss observation, you've been a dedicated worker.";
            }
        }
        else{
            content[2] = "You worked as a freelancer. Lots of pain and sweat to earn money.";
            if(withInsurance){
                content[3] = "You are a cautious person. You bought the insurance!";
            }
            else{
                content[3] = "You are a risk bearer. What is insurance? Never heard of it.";
            }
        }

        //Money
        if(money == 30){
            content[4] = "You're a responsible money maker. You earned " + money + " dollars";
        }
        else if(money < 30){
            content[4] = "You have a rough time making money. You've only made " + money + " dollars. Should've switch your path huh?";
        }
        else{
            content[4] = "You're an overachiever with an eager to make money. Congratulations on making " + money + " dollars!";
        }
    }

    public void Press(){
        if(number < 5){
            myText.text = content[number];
            number ++;
        }
        else{
            SceneManager.LoadScene("Final");
        }
    }
}
