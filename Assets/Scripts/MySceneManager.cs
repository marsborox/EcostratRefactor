using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MySceneManager : SingletonPresistent<MySceneManager>
{
    public static new MySceneManager instance => SingletonPresistent<MySceneManager>.instance;

    //public static MySceneManager instance;

    void Start()
    {
        //instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
    void Test()
    {

    }
}
