using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GameStart(){
        SceneManager.LoadScene("Game");
    }
    public void GameMenu(){
        SceneManager.LoadScene("StartScene");
    }
    public void Exit(){
        Application.Quit();
    }
    
}
