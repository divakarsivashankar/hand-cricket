using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int playerScore = 0;
    private int botScore = 0;
    private bool isPlayerPlaying;
    private int target = 0;
    private bool isFirstInnings = true;
    
    public int getPlayerScore(){
        return this.playerScore;
    }
    public void setPlayerScore(int playerScore){
        this.playerScore = playerScore;
    }
    public void setBotScore(int botScore){
        this.botScore = botScore;
    }
    public int getBotScore(){
        return this.botScore;
    }
    public void setTarget(int target){
        this.target = target;
    }
    public int getTarget(){
        return this.target;
    }
    public bool getIsPlayerPlaying(){
        return this.isPlayerPlaying;
    }
    public void setIsPlayerPlaying(bool isPlayerPlaying){
        this.isPlayerPlaying = isPlayerPlaying;
    }
    public bool getIsFirstInnings(){
        return this.isFirstInnings;
    }
    public void setIsFirstInnings(bool isFirstInnings){
        this.isFirstInnings = isFirstInnings;
    }

}
