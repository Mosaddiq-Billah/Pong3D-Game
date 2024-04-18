using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemenumanager : MonoBehaviour
{
    public GameObject playbutton;
    public void Playbtn()
    {
        SceneManager.LoadScene("Scene_Workshop");
    }
    public void Optionbtn()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Highscoremenu()
    {
        SceneManager.LoadScene("MenuScene 1");
    }

}
