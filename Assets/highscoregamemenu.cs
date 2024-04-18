using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class highscoregamemenu : MonoBehaviour
{
    public Text highestscore;
    // Start is called before the first frame update
    void Start()
    {
        highestscore.text = PlayerPrefs.GetInt("PlayerHighScore").ToString();
        
    }

    
    public void exit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
