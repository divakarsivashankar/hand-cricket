using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    
    public void gotoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void gotoTossScene()
    {
        SceneManager.LoadScene("TossScene");
    }
    public void gotoMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void gotoElectScene()
    {
        SceneManager.LoadScene("ElectScene");
    }
    public void gotoGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void exitGame()
    {
       Application.Quit();
    }

}
