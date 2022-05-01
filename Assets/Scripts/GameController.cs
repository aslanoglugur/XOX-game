using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameController : MonoBehaviour
{
    public int whoseTurn;  //   0 = x, 1 = y
    public int turnCounter;

    public Sprite[] playerIcons;
    public Button[] xoxSpaces;
    public Button resetButton;

    public List<int> Liste;
    public bool bitti=false;

    public Text winner;
    // Start is called before the first frame update
    void Start()
    {
        InitialisePageComponents();


                
    }

    public void InitialisePageComponents(){
        whoseTurn = 0;
        turnCounter = 0;
        bitti = false;

        for(int i = 0; i<xoxSpaces.Length; i++){
            xoxSpaces[i].interactable = true;
            xoxSpaces[i].image.sprite = null;
            Liste[i] = 10;
            

        }


    }

    public void XoxButton(int whichNumber){

        xoxSpaces[whichNumber].interactable = false;
        xoxSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
        Liste[whichNumber]=whoseTurn;

        Check(turnCounter,whoseTurn);


        if(whoseTurn == 0){
            whoseTurn = 1;
        }
        else{
            whoseTurn = 0;
        }
        turnCounter++;

    }

    public void Check(int turnCounter1, int whoseTurn){
        int cond01 = Liste[0]+Liste[1]+Liste[2];
        int cond02 = Liste[3]+Liste[4]+Liste[5];
        int cond03 = Liste[6]+Liste[7]+Liste[8];
        int cond04 = Liste[0]+Liste[3]+Liste[6];
        int cond05 = Liste[1]+Liste[4]+Liste[7];
        int cond06 = Liste[2]+Liste[5]+Liste[8];
        int cond07 = Liste[0]+Liste[4]+Liste[8];
        int cond08 = Liste[2]+Liste[4]+Liste[6];


        if(cond01 == 0  || cond01 ==3){

            bitti = true;

        }
        else if(cond02 == 0  || cond02 ==3){
            bitti = true;

        }
        else if(cond03 == 0  || cond03 ==3){
            bitti = true;

        }
        else if(cond04 == 0  || cond04 ==3){
            bitti = true;

        }
        else if(cond05 == 0  || cond05 ==3){
            bitti = true;

        }
        else if(cond06 == 0  || cond06 ==3){
            bitti = true;

        }
        else if(cond07 == 0  || cond07 ==3){
            bitti = true;

        }
        else if(cond08 == 0  || cond08 ==3){
            bitti = true;
        }



    
        Oyunbitti(bitti,turnCounter1, whoseTurn);

        
        
      

    }

   public void Oyunbitti(bool bitti2 , int turnCounter2, int whoseTurn){

        if(bitti==true){
            if(whoseTurn == 0){
                winner.GetComponent<Text>().text = "X Wins!";
            }
            else{
                winner.GetComponent<Text>().text = "O Wins!";
            }
            for(int i = 0; i<xoxSpaces.Length; i++){
            xoxSpaces[i].interactable = false;

            }
            
            
        }


        if(bitti==false && turnCounter2==8){
            winner.GetComponent<Text>().text = "DRAW";
            
        }
    
    }
    public void Reset(){
        winner.GetComponent<Text>().text = "";

        Start();
    }
}
