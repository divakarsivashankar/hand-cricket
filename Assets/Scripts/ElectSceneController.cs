using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectSceneController : MonoBehaviour
{
    Button batButton;
    Button bowlButton;

    void Start()
    {
        batButton = GameObject.Find ("Bat_Button").GetComponent<Button>();
        bowlButton = GameObject.Find ("Bowl_Button").GetComponent<Button>();
        batButton.onClick.AddListener(() => playGame(true));
        bowlButton.onClick.AddListener(() => playGame(false));


    }
    public void playGame(bool choice){
        GameData.Toss = choice;
        ChangeLevel changeLevel = new ChangeLevel();
        changeLevel.gotoGameScene();
        
    }
}
