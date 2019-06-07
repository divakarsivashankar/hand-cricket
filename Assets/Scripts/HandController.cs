using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    // Start is called before the first frame update

    Button duckButton;
    Button oneButton;
    Button twoButton;
    Button threeButton;
    Button fourButton;
    Button fiveButton;
    Button sixButton;
    Text playerScoreText;
    Text botScoreText;

    private bool batting;
    private int wickets = 0;
    private int deliveries = 0;
    private Game game = new Game();
    void Start()
    {
        batting = GameData.Toss;
        //batting = false;
        game.setIsPlayerPlaying(batting);
        duckButton = GameObject.Find ("Duck_Button").GetComponent<Button>();
        oneButton = GameObject.Find ("One_Button").GetComponent<Button>();
        twoButton = GameObject.Find ("Two_Button").GetComponent<Button>();
        threeButton = GameObject.Find ("Three_Button").GetComponent<Button>();
        fourButton = GameObject.Find ("Four_Button").GetComponent<Button>();
        fiveButton = GameObject.Find ("Five_Button").GetComponent<Button>();
        sixButton = GameObject.Find ("Six_Button").GetComponent<Button>();
        playerScoreText = GameObject.Find("Your_Score").GetComponent<Text>();
        botScoreText = GameObject.Find("Bot_Score").GetComponent<Text>();
        duckButton.onClick.AddListener(() => buttonCallBack(duckButton));
        oneButton.onClick.AddListener(() => buttonCallBack(oneButton));
        twoButton.onClick.AddListener(() => buttonCallBack(twoButton));
        threeButton.onClick.AddListener(() => buttonCallBack(threeButton));
        fourButton.onClick.AddListener(() => buttonCallBack(fourButton));
        fiveButton.onClick.AddListener(() => buttonCallBack(fiveButton));
        sixButton.onClick.AddListener(() => buttonCallBack(sixButton));

    }

    private void buttonCallBack(Button buttonPressed) {
        //bool isOut = false;
        deliveries += 1;
        int newScore = getRuns(buttonPressed, game.getIsPlayerPlaying());
        if(newScore == -1){
            //isOut = true;
            wickets += 1;
        }
        bool playerIsPlaying = game.getIsPlayerPlaying();
        bool isFirstInnings = game.getIsFirstInnings();
        //if (isOut){
        if(wickets == 10 || deliveries == 30){
            if(playerIsPlaying){
                playerScoreText.text += " - Final Score";
                game.setIsPlayerPlaying(false);
                if(game.getIsFirstInnings()){
                    game.setIsFirstInnings(false);
                    game.setTarget(getPlayerScore()+1);
                    deliveries = 0;
                    wickets = 0;
                } else {
                    goToGameOverScreen("game over");
                }
            } else {
                botScoreText.text += " - Final Score";
                game.setIsPlayerPlaying(true);
                if(game.getIsFirstInnings()){
                    game.setIsFirstInnings(false);
                    game.setTarget(getBotScore()+1);
                    deliveries = 0;
                    wickets = 0;
                } else {
                    goToGameOverScreen("game over");
                }
            }
        } else {
            if(playerIsPlaying){
                game.setPlayerScore(newScore);
                playerScoreText.text = newScore.ToString();
                if(!isFirstInnings){
                    chachingInProgress(playerIsPlaying);
                } 
            } else {
                game.setBotScore(newScore);
                botScoreText.text = newScore.ToString();
                if(!isFirstInnings){
                    chachingInProgress(playerIsPlaying);
                }
            }
        }
    }

    private int generateBotMove(){
        System.Random rnd = new System.Random();
        int num   = rnd.Next(0, 6);
        return num;
    }

    private int getRuns(Button buttonPressed, bool player){
        int newScore = -1;
        int botMove = generateBotMove();
        int playerMove = getButtonValue(buttonPressed);
        if(playerMove != botMove){
            if(player){
                newScore = getPlayerScore() + playerMove;
            } else {
                newScore = getBotScore() + botMove; 
            }
        }
        return newScore;
    }

    private int getBotScore(){
        return game.getBotScore();
    }
    private int getPlayerScore(){
        return game.getPlayerScore();
    }
    private void goToGameOverScreen(string sceneName){
        ChangeLevel changeLevel = new ChangeLevel();
        if(sceneName == "game over"){
            changeLevel.gotoGameOverScene();
        } else {
            changeLevel.gotoTossScene();
        }
    }

    private void chachingInProgress(bool player){
        int target = game.getTarget();
        int currentScore = 0;
        if(player){
            currentScore = getPlayerScore();
        } else {
            currentScore = getBotScore();
        }
        if(currentScore >= target){
            if(player){
                goToGameOverScreen("win");
            } else {
                goToGameOverScreen("game over");
            }
        }
    }

    private int getButtonValue(Button buttonPressed){
        int buttonValue = 0;
        if (buttonPressed == duckButton)
        {
            buttonValue = 0;
            //Debug.Log("Clicked: " + duckButton.name);
        }
        else if (buttonPressed == oneButton)
        {
            buttonValue = 1;
            //Debug.Log("Clicked: " + oneButton.name);
        }

        else if (buttonPressed == twoButton)
        {
            buttonValue = 2;
            //Debug.Log("Clicked: " + twoButton.name);
        }
        else if (buttonPressed == threeButton)
        {
            buttonValue = 3;
            //Debug.Log("Clicked: " + threeButton.name);
        }
        else if (buttonPressed == fourButton)
        {
            buttonValue = 4;
            //Debug.Log("Clicked: " + fourButton.name);
        }
        else if (buttonPressed == fiveButton)
        {
            buttonValue = 5;
            //Debug.Log("Clicked: " + fiveButton.name);
        }
        else if (buttonPressed == sixButton)
        {
            buttonValue = 6;
            //Debug.Log("Clicked: " + sixButton.name);
        }
        return buttonValue;
    }



//------------------------------- no used now -------------------------//
    // private bool matchStart(){
    //     string playeTextToCompare = playerScoreText.text;
    //     string botTextToCompare = botScoreText.text;
    //     if(playeTextToCompare == "XXX" &&  botTextToCompare == "XXX") {
    //         return true;
    //     }
    //     return false;
    // }



    // private bool findWhoPlays(){
    //     bool isPlayer = false;
    //     if(matchStart()){
    //         if(batting){
    //             return true;
    //         } else {
    //             return false;
    //         }
    //     }
    //     string playerTextToCompare = playerScoreText.text;
    //     if(playerTextToCompare != "XXX" && batting) {
    //         if(!playerTextToCompare.Contains("- Final Score")){
    //             isPlayer =  true;
    //         }
    //     }
    //     string botTextToCompare = botScoreText.text;
    //     if(botTextToCompare != "XXX" && !batting) {
    //         if(!botTextToCompare.Contains("- Final Score")){
    //             isPlayer =  false;
    //         }
    //     }
    //     return isPlayer;
    // }


    // private void updateTarget(bool player){
    //     if(player){
    //         Debug.Log("got true: ");
    //         target = playerScore+1;
    //     } else {
    //         Debug.Log("got false: ");
    //         target = botScore+1;
    //     }
                    
    // }
    // private void checkHalfway(){
    //     if(halways){
    //         goToGameOverScreen("game over");
    //     } else {
    //         halways = true;
    //     }
    // }

//------------------------------- no used now -------------------------//

    // private void buttonCallBack_1(Button buttonPressed) {
    //     bool isOut = false;
    //     bool chase = false;
    //     int newScore = getRuns(buttonPressed, batting);
    //     if(newScore == -1){
    //             isOut = true;
    //     }
    //     if (isOut){
    //         if(findWhoPlays()){
    //             playerScoreText.text += " - Final Score";
    //             checkHalfway();
    //             updateTarget(true);
    //         } else {
    //             botScoreText.text += " - Final Score";
    //             checkHalfway();
    //             updateTarget(false);
    //         }
    //     } else {
    //         if(findWhoPlays()){
    //             playerScore = newScore;
    //             playerScoreText.text = newScore.ToString();
    //             if(halways){
    //                 chachingInProgress(target,true,playerScore);
    //             } 
    //         } else {
    //             botScore = newScore;
    //             botScoreText.text = newScore.ToString();
    //             if(halways){
    //                 chachingInProgress(target,false,botScore);
    //             }
    //         }
    //     }
    // }

//-----------------------------------------------------------------

    // private void buttonCallBack_old(Button buttonPressed, bool batting) {
    //     if (!gameOver){
    //         bool isOut = false;
    //         if (batting) {
    //             int newScore = getRuns(buttonPressed, findWhoPlays());
    //             if(newScore == -1){
    //                 isOut = true;
    //             }
    //             if (isOut){
    //                 playerScoreText.text += " - Final Score";
    //                 if(halways){
    //                     goToGameOverScreen("game over");
    //                 } else {
    //                     halways = true;
    //                 }
    //                 batting = false;
    //                 updateTarget();
    //                 chasing = true;
    //             } else {
    //                 playerScore = newScore;
    //                 playerScoreText.text = newScore.ToString();
    //                 if(chasing){
    //                     chachingInProgress(target,!findWhoPlays(),buttonPressed,playerScore);
    //                 }   
    //             }

    //         } else {
    //             int newScore = getRuns(buttonPressed,findWhoPlays());
    //             if(newScore == -1){
    //                 isOut = true;
    //             }
    //             if (isOut){
    //                 botScoreText.text += " - Final Score";
    //                 if(halways){
    //                     goToGameOverScreen("game over");
    //                 } else {
    //                     halways = true;
    //                 }
    //                 batting = true;
    //                 updateTarget();
    //                 chasing = true;  
    //             } else {
    //                 botScore = newScore;
    //                 botScoreText.text = newScore.ToString();
    //                 int currentScore = 0;
    //                 if(findWhoPlays()){
    //                     currentScore = playerScore;
    //                 } else{
    //                     currentScore = botScore;
    //                 }
    //                 if(chasing){
    //                     chachingInProgress(target,!findWhoPlays(),buttonPressed,botScore);
    //                 }
    //             }
    //         } 
    //     }
    // }

}
