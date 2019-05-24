using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class TossController : MonoBehaviour
{

    private Text TextUI = GameObject.Find("result").GetComponent<Text>();
    // private bool toss_result;
    public static bool wonToss;

    Button headButton;
    Button tailButton;
    Button retossButton;
    Button playButton;
    Text tossResultText;

    void Start()
    {
        headButton = GameObject.Find ("head_button").GetComponent<Button>();
        tailButton = GameObject.Find ("tail_button").GetComponent<Button>();
        retossButton = GameObject.Find ("re_toss_button").GetComponent<Button>();
        playButton = GameObject.Find ("go_to_game_button").GetComponent<Button>();
        tossResultText = GameObject.Find("result").GetComponent<Text>();
        headButton.onClick.AddListener(() => flipToss("head"));
        tailButton.onClick.AddListener(() => flipToss("tail"));
        retossButton.onClick.AddListener(() => buttonCallBack(retossButton));
        playButton.onClick.AddListener(() => buttonCallBack(playButton));

    }


    public void flipToss(string choice){
        System.Random rnd = new System.Random();
        int num   = rnd.Next(1, 100);
        string toss = null;
        bool success = false;
        if (num % 2 == 0){
            toss = "head";
        } else{
            toss = "tail";
        }

        if (choice == toss){
            success = true;
        } 
        
        if(success){
            tossResultText.text += "You Won";
        } else {
            tossResultText.text += "You Lost";
        }
        
        wonToss = success;
        GameData.Toss = success;
    }

    public void playButttonOnClick(){
        ChangeLevel changeLevel = new ChangeLevel();
        if(!wonToss){
            changeLevel.gotoGameScene();
        } else {
            changeLevel.gotoElectScene();
        }
    }

    private void changeLevel(string level){
        ChangeLevel changeLevel = new ChangeLevel();
         if (level == "retoss")
        {
            changeLevel.gotoTossScene();
        }
        else if (level == "play")
        {
            playButttonOnClick();
        }
        
    }

    private string buttonCallBack(Button buttonPressed){
        string buttonValue = "";
        if (buttonPressed == retossButton)
        {
            changeLevel("retoss");
            //Debug.Log("Clicked: " + twoButton.name);
        }
        else if (buttonPressed == playButton)
        {
            GameData.Toss = wonToss;
            changeLevel("play");
            //Debug.Log("Clicked: " + threeButton.name);
        }
        return buttonValue;
    }


}
